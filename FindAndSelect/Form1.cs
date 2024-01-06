using FindAndSelect.Objects;
using FindAndSelect.Utils;
using System.IO;
using System.Windows.Forms;

namespace FindAndSelect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Config config;
        List<Paper> papers;
        List<string> keyWords;
        Dictionary<string, int> keyWordsDict;
        List<Paper> searchRes;
        //List<KeyWord> keyWords;

        private void Form1_Load(object sender, EventArgs e)
        {
            //��ʼ�����ڲ���
            keywordListView.MultiSelect = false;
            keywordListView.View = View.Details;
            keywordListView.Columns.Add("�ؼ���", 200, HorizontalAlignment.Left);
            keywordListView.Columns.Add("���ִ���", 100, HorizontalAlignment.Left);

            paperListView.MultiSelect = false;
            paperListView.View = View.Details;
            paperListView.Columns.Add("���ı���", 180, HorizontalAlignment.Left);
            paperListView.Columns.Add("�����Ĺؼ���", 180, HorizontalAlignment.Left);

            searchListView.MultiSelect = false;
            searchListView.View = View.Details;
            searchListView.Columns.Add("���ı���", 400, HorizontalAlignment.Left);
            searchListView.Columns.Add("�����Ĺؼ���", 300, HorizontalAlignment.Left);


            //��������
            config = Functions.ReadConfig("./config.json");

            Update();
        }
        private void ReUpdate()
        {
            keywordListView.Items.Clear();
            paperListView.Items.Clear();
            searchListView.Items.Clear();
            titleBox.Text = keyWordBox.Text = contentBox.Text = string.Empty;
            Update();
        }
        private void Update()
        {
            //��ʼ������
            papers = new();
            keyWords = new();
            keyWordsDict = new();
            foreach (var key in config.KeyWords)
            {
                keyWords.Add(key);
                keyWordsDict.Add(key, 0);
            }

            //ͳ��
            if (Directory.Exists("./Papers"))
            {
                DirectoryInfo info = new("./Papers");
                var files = info.GetFiles("*.txt");
                foreach (var item in files)
                {

                    try
                    {
                        string text = File.ReadAllText(item.FullName);
                        var p = Functions.ReadPaper(Path.GetFileNameWithoutExtension(item.Name), text, keyWords);
                        papers.Add(p);
                        foreach (var k in p.KeyWords)
                            keyWordsDict[k.Key] += k.Value > 0 ? 1 : 0;

                    }
                    catch { }
                }
            }

            //listView
            keywordListView.BeginUpdate();
            foreach (var key in keyWordsDict)
            {
                ListViewItem item = new();
                item.Text = key.Key;
                item.SubItems.Add(key.Value.ToString());
                keywordListView.Items.Add(item);
            }
            keywordListView.EndUpdate();
            paperListView.BeginUpdate();
            foreach (var p in papers)
            {
                ListViewItem item = new();
                item.Text = p.Name;
                item.SubItems.Add(Functions.ContainKeyWords(p));
                paperListView.Items.Add(item);
            }
            paperListView.EndUpdate();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var word = addBox.Text.ToLower();
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("������ؼ���!");
                return;
            }
            if (config.KeyWords.Contains(word))
            {
                MessageBox.Show("�����������ظ��Ĺؼ���!");
                return;
            }


            config.KeyWords.Add(word);
            Functions.SaveConfig(config, "./config.json");
            ReUpdate();

        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var select = keywordListView.SelectedIndices;
            if (select.Count == 1)
            {
                config.KeyWords.RemoveAt(select[0]);
                Functions.SaveConfig(config, "./config.json");
                excludeButton.Enabled = includeButton.Enabled = deleteButton.Enabled = false;
                ReUpdate();
            }
        }

        private void keywordListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }
            var label = e.Label.ToLower();
            if (label == config.KeyWords[e.Item])
                return;

            config.KeyWords[e.Item] = label;
            Functions.SaveConfig(config, "./config.json");
            ReUpdate();
        }

        private void keywordListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = keywordListView.SelectedIndices;
            excludeButton.Enabled = includeButton.Enabled = deleteButton.Enabled = select.Count == 1;
            /*
            if (select.Count == 1)
            
                //var index = select[0];
                deleteButton.Enabled = true;
            else
                deleteButton.Enabled = false;*/
        }

        private void exludeButton_Click(object sender, EventArgs e)
        {
            var select = keywordListView.SelectedIndices;
            if (select.Count == 1)
            {
                var key = keyWords[select[0]];
                if (Functions.IsRepeat(excludeBox.Text, key))
                {
                    MessageBox.Show("�����ظ����ͬһ�ؼ���!");
                    return;
                }
                if (Functions.IsRepeat(includeBox.Text, key))
                {
                    MessageBox.Show("�����ڰ������ų��б������ͬһ�ؼ���!");
                    return;
                }
                excludeBox.Text += $",{key}";
            }
        }

        private void includeButton_Click(object sender, EventArgs e)
        {
            var select = keywordListView.SelectedIndices;
            if (select.Count == 1)
            {
                var key = keyWords[select[0]];
                if (Functions.IsRepeat(includeBox.Text, key))
                {
                    MessageBox.Show("�����ظ����ͬһ�ؼ���!");
                    return;
                }
                if (Functions.IsRepeat(excludeBox.Text, key))
                {
                    MessageBox.Show("�����ڰ������ų��б������ͬһ�ؼ���!");
                    return;
                }
                includeBox.Text += $",{key}";
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchListView.Items.Clear();
            searchListView.BeginUpdate();
            var res = Functions.GetSearchKeyWords(includeBox.Text, excludeBox.Text, keyWords);
            if (res == null)
                return;
            (List<string[]> include, List<string[]> declude) = ((List<string[]>, List<string[]>))res;
            searchRes = new();
            foreach (var paper in papers)
            {
                foreach (var inc in include)
                {
                    foreach(var key in inc)
                    {
                        if (paper.KeyWords[key] > 0)
                            goto Continue;
                    }
                    goto Next;
                Continue: { }
                }
                foreach (var dec in declude)
                {
                    foreach (var key in dec)
                    {
                        if (paper.KeyWords[key] == 0)
                            goto Continue;
                    }
                    goto Next;
                Continue: { }
                }

                searchRes.Add(paper);

            Next:
                { }
            }

            Console.WriteLine(searchRes.Count);
            foreach (var paper in searchRes)
            {
                
                ListViewItem item = new();
                item.Text = paper.Name;
                item.SubItems.Add(Functions.ContainKeyWords(paper));
                searchListView.Items.Add(item);
            }

            searchListView.EndUpdate();
        }


        private void paperListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = paperListView.SelectedIndices;
            if (select.Count == 1)
            {
                //var index = select[0];
                var paper = papers[select[0]];

                titleBox.Text = paper.Name;
                keyWordBox.Text = Functions.ContainKeyWords(paper);
                try
                {
                    string text = File.ReadAllText(Path.Combine("./Papers", paper.Name + ".txt"));
                    contentBox.Text = text;
                }
                catch
                {
                    contentBox.Text = "��ȡ����ժҪʧ��!";
                }
            }
        }
        private void searchListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = searchListView.SelectedIndices;
            if (select.Count == 1)
            {
                //var index = select[0];
                var paper = searchRes[select[0]];

                titleBox.Text = paper.Name;
                keyWordBox.Text = Functions.ContainKeyWords(paper);
                try
                {
                    string text = File.ReadAllText(Path.Combine("./Papers", paper.Name + ".txt"));
                    contentBox.Text = text;
                }
                catch
                {
                    contentBox.Text = "��ȡ����ժҪʧ��!";
                }
            }

        }

        private void flushButton_Click(object sender, EventArgs e)
        {
            ReUpdate();
        }
    }
}