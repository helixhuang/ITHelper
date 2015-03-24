using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RunasGui
{
    public partial class MainForm : Form
    {
        private const string DATA_FILE = "RunasData.json";
        private BindingList<RunasObject> _runasList;
        private bool _isNew = false;
        private RunasObject _currentObject;
        public MainForm()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            _runasList = new BindingList<RunasObject>();
            if (File.Exists(DATA_FILE))
            {
                _runasList = JsonConvert.DeserializeObject<BindingList<RunasObject>>(File.ReadAllText(DATA_FILE, Encoding.UTF8));
            }
            runasObjectListBox.DataSource = _runasList;

        }
        private void SaveData()
        {
            File.WriteAllText(DATA_FILE, JsonConvert.SerializeObject(_runasList, Formatting.Indented), Encoding.UTF8);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _isNew = true;
            UpdateCurrentObject(new RunasObject());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentObjectValue();

            if (_isNew || _runasList.Count == 0)
            {
                _runasList.Add(_currentObject);
                SaveData();
                runasObjectListBox.SelectedItem = _currentObject;
            }
            else
            {
                SaveData();
            }
            _isNew = false;
            runasObjectListBox.Refresh();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            UpdateCurrentObjectValue();
            RunasHelper.Runas(_currentObject);
        }

        private void runasObjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunasObject runas = runasObjectListBox.SelectedItem as RunasObject;
            UpdateCurrentObject(runas);
        }

        private void runasObjectListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RunasHelper.Runas((sender as RunasObjectListBox).SelectedItem as RunasObject);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_isNew && runasObjectListBox.SelectedItem != null)
            {
                _isNew = false;
                UpdateCurrentObject(runasObjectListBox.SelectedItem as RunasObject);
            }
            else if (runasObjectListBox.SelectedItem != null)
            {
                _runasList.Remove(_currentObject);
                SaveData();
            }
        }

        private void UpdateCurrentObject(RunasObject newObj)
        {
            _currentObject = newObj;
            if (_currentObject != null)
            {
                tbName.Text = _currentObject.Name;
                tbPath.Text = _currentObject.ExeFile;
                tbArg.Text = _currentObject.Args;
                tbDomain.Text = _currentObject.Domain;
                tbUserName.Text = _currentObject.UserName;
                tbPassword.Text = _currentObject.GetPassword();
            }
            else
            {
                tbName.Text = "";
                tbPath.Text = "";
                tbArg.Text = "";
                tbDomain.Text = "";
                tbUserName.Text = "";
                tbPassword.Text = "";
            }

        }

        private void UpdateCurrentObjectValue()
        {
            if (_currentObject == null)
            {
                _currentObject = new RunasObject();
            }
            _currentObject.Name = tbName.Text;
            _currentObject.ExeFile = tbPath.Text;
            _currentObject.Args = tbArg.Text;
            _currentObject.Domain = tbDomain.Text;
            _currentObject.UserName = tbUserName.Text;
            _currentObject.SetPassword(tbPassword.Text);
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Application files (*.exe)|*.exe";
            diag.RestoreDirectory = true;
            if (diag.ShowDialog(this) == DialogResult.OK)
            {
                tbPath.Text = diag.FileName;
            }
        }

        private void btnShortcut_Click(object sender, EventArgs e)
        {
            if (_isNew)
            {
                MessageBox.Show("请先保存");
            }
            if (string.IsNullOrEmpty(_currentObject.ExeFile)
                || string.IsNullOrEmpty(_currentObject.Name))
            {
                MessageBox.Show("数据不完整");
            }
            Icon appIcon = Icon.ExtractAssociatedIcon(_currentObject.ExeFile);
            if (!Directory.Exists("Icons")) Directory.CreateDirectory("Icons");
            string iconFile = string.Format("{0}\\Icons\\{1}.ico", System.Environment.CurrentDirectory, _currentObject.Name);
            using (FileStream fs = new FileStream(iconFile, FileMode.Create))
            {
                appIcon.Save(fs);
            }

            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(String.Format("{0}\\{1}.lnk", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), _currentObject.Name));
            shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            shortcut.Arguments = _currentObject.Name;
            shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
            shortcut.IconLocation = iconFile;
            shortcut.Save();
        }

    }
}
