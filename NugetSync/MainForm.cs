using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace NugetSync
{
    public partial class MainForm : Form
    {
        #region private fileds
        const string packagesConfig = "packages.config";
        const string csprojExtension = ".csproj";
        string lastFolderBrowserdir = string.Empty; //记忆上次打开文件

        static readonly string helpString =
            "Nuget同步通常需要同步“packages.config”和“.csproj”两个文件" + Environment.NewLine +
            "来源选择同步来源文件，“packages.config”和“.csproj”全路径" + Environment.NewLine +
            "目标选择同步目标文件，“packages.config”和“.csproj”全路径" + Environment.NewLine +
            "支持文本框内直接填写文件路径，一行代表一个路径" + Environment.NewLine +
            "勾选更新按钮，遇到相同的包，会更新" + Environment.NewLine +
            "勾选新增按钮，来源中存在而目标中不存在的包，会添加" + Environment.NewLine +
            "作者联系方式：LightKitty@126.com"
            ;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.RestoreDirectory = true;
                ofd.Filter = "C#项目文件|*.csproj|程序包文件|packages.config|所有文件|*.*";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string[] paths = ofd.FileNames;
                    foreach (string path in paths)
                    {
                        textBox1.AppendText(path + Environment.NewLine);
                    }
                }
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.RestoreDirectory = true;
                ofd.Filter = "C#项目文件|*.csproj|程序包文件|packages.config|所有文件|*.*";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string[] paths = ofd.FileNames;
                    foreach (string path in paths)
                    {
                        textBox2.AppendText(path + Environment.NewLine);
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string[] paths1 = Regex.Split(textBox1.Text.TrimEnd(Environment.NewLine.ToArray()), Environment.NewLine);
                foreach (string path1 in paths1)
                {
                    if (!File.Exists(path1))
                    {
                        MessageBox.Show($"来源文件 {path1} 不存在！");
                        return;
                    }
                }

                string[] paths2 = Regex.Split(textBox2.Text.TrimEnd(Environment.NewLine.ToArray()), Environment.NewLine);
                foreach (string path2 in paths2)
                {
                    if (!File.Exists(path2))
                    {
                        MessageBox.Show($"目标文件 {path2} 不存在！");
                        return;
                    }
                }

                var packagesConfigPaths = new List<string>();
                var csprojPaths = new List<string>();
                foreach (var path in paths1)
                {
                    var fileName = Path.GetFileName(path);
                    if (fileName.ToLower() == packagesConfig)
                    {
                        packagesConfigPaths.Add(path);
                    }
                    else if (Path.GetExtension(fileName).ToLower() == csprojExtension)
                    {
                        csprojPaths.Add(path);
                    }
                }

                Dictionary<string, XElement> packageDic = ReadPackagesConfig(packagesConfigPaths);
                Dictionary<string, XElement> referenceDic = ReadCsproj(csprojPaths);

                bool isUpdate = checkBoxUpdate.Checked;
                bool isAdd = checkBoxAdd.Checked;

                //更新目标
                foreach (string path2 in paths2)
                {
                    if (!File.Exists(path2))
                    {
                        continue;
                    }

                    var fileName = Path.GetFileName(path2);
                    if (fileName.ToLower() == packagesConfig)
                    { //packages.config
                        RepairPackageConfig(path2, packageDic, isUpdate, isAdd);
                    }
                    else if (Path.GetExtension(fileName).ToLower() == csprojExtension)
                    { //.csproj
                        RepairCsprojConfig(path2, referenceDic, isUpdate, isAdd);
                    }
                }

                MessageBox.Show("同步成功！", "提示");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 修复packages.config
        /// </summary>
        /// <param name="path"></param>
        /// <param name="packageDic"></param>
        /// <param name="isUpdate">是否更新</param>
        /// <param name="isAdd">是否新增</param>
        private void RepairPackageConfig(string path, Dictionary<string, XElement> packageDic, bool isUpdate, bool isAdd)
        {
            XDocument xd = XDocument.Load(path);
            var packages = xd.Descendants("packages").FirstOrDefault();
            var packageList = packages.Descendants("package");
            for (int i = 0; i < packageList.Count(); i++)
            {
                string id = packageList.ElementAt(i).Attribute("id").Value;
                if (packageDic.TryGetValue(id, out XElement tn))
                {
                    if(isUpdate) packageList.ElementAt(i).ReplaceWith(tn); //更新
                    packageDic.Remove(id); //移除掉更新的
                }
            }

            if(isAdd) packages.Add(packageDic.Values); //添加没有的

            xd.Save(path);
        }

        /// <summary>
        /// 修复.csproj文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="csprojDic"></param>
        /// <param name="isUpdate">是否更新</param>
        /// <param name="isAdd">是否新增</param>
        private void RepairCsprojConfig(string path, Dictionary<string, XElement> csprojDic, bool isUpdate, bool isAdd)
        {
            XDocument xd = XDocument.Load(path);
            var references = xd.Descendants().Where(x => x.Name.LocalName == "Reference");
            var itemGroup = references.First().Parent;
            for (int i = 0; i < references.Count(); i++)
            {
                var reference = references.ElementAt(i);
                string include = reference.Attribute("Include").Value;
                string id = include.Split(',').First().Trim();
                if (csprojDic.TryGetValue(id, out XElement tn))
                {
                    if(isUpdate) references.ElementAt(i).ReplaceWith(tn);
                    csprojDic.Remove(id); //移除掉更新的
                }
            }

            if(isAdd) itemGroup.Add(csprojDic.Values); //添加没有的

            xd.Save(path);
        }

        /// <summary>
        /// 打开目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDir1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (Directory.Exists(lastFolderBrowserdir)) fbd.SelectedPath = lastFolderBrowserdir;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string dir = fbd.SelectedPath;
                    DirectoryInfo root = new DirectoryInfo(dir);
                    FileInfo[] files = root.GetFiles();
                    foreach (var file in files)
                    {
                        if (file.Name.ToLower() == packagesConfig || Path.GetExtension(file.Name).ToLower() == csprojExtension)
                        {
                            textBox1.AppendText(file.FullName);
                        }
                    }
                    lastFolderBrowserdir = dir;
                }
            }
        }

        /// <summary>
        /// 打开目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDir2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (Directory.Exists(lastFolderBrowserdir)) fbd.SelectedPath = lastFolderBrowserdir;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string dir = fbd.SelectedPath;
                    DirectoryInfo root = new DirectoryInfo(dir);
                    FileInfo[] files = root.GetFiles();
                    foreach (var file in files)
                    {
                        if (file.Name.ToLower() == packagesConfig || Path.GetExtension(file.Name).ToLower() == csprojExtension)
                        {
                            textBox2.AppendText(file.FullName);
                        }
                    }
                    lastFolderBrowserdir = dir;
                }
            }  
        }

        /// <summary>
        /// 读取packages.config
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        private Dictionary<string, XElement> ReadPackagesConfig(IEnumerable<string> paths)
        {
            Dictionary<string, XElement> nugetDic = new Dictionary<string, XElement>();
            //读取源
            foreach (string path in paths)
            {
                if (!File.Exists(path))
                {
                    continue;
                }
                XDocument xd = XDocument.Load(path);
                XElement packages = xd.Descendants("packages").FirstOrDefault();
                List<XElement> packageList = packages.Descendants("package").ToList();
                foreach (XElement package in packageList)
                {
                    string id = package.Attribute("id").Value;
                    if (!nugetDic.ContainsKey(id)) nugetDic.Add(id, package);
                }
            }

            return nugetDic;
        }

        /// <summary>
        /// 读取***.csproj
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        private Dictionary<string, XElement> ReadCsproj(IEnumerable<string> paths)
        {
            Dictionary<string, XElement> nugetDic = new Dictionary<string, XElement>();
            foreach (string path in paths)
            {
                if (!File.Exists(path))
                {
                    continue;
                }
                XDocument xd = XDocument.Load(path);
                var references = xd.Descendants().Where(x=>x.Name.LocalName== "Reference");
                foreach (XElement reference in references)
                {
                    string include = reference.Attribute("Include").Value;
                    string id = include.Split(',').First().Trim();
                    if (!nugetDic.ContainsKey(id)) nugetDic.Add(id, reference);
                }
            }
            return nugetDic;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(helpString, "帮助");
        }
    }
}
