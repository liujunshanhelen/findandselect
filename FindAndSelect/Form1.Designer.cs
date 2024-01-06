namespace FindAndSelect
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            keywordListView = new ListView();
            label2 = new Label();
            paperListView = new ListView();
            groupBox1 = new GroupBox();
            label5 = new Label();
            searchListView = new ListView();
            searchButton = new Button();
            excludeBox = new TextBox();
            label4 = new Label();
            includeBox = new TextBox();
            label3 = new Label();
            includeButton = new Button();
            excludeButton = new Button();
            groupBox2 = new GroupBox();
            contentBox = new TextBox();
            label9 = new Label();
            keyWordBox = new TextBox();
            label8 = new Label();
            titleBox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            addBox = new TextBox();
            addButton = new Button();
            flushButton = new Button();
            deleteButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "关键词表";
            // 
            // keywordListView
            // 
            keywordListView.FullRowSelect = true;
            keywordListView.LabelEdit = true;
            keywordListView.Location = new Point(12, 71);
            keywordListView.Name = "keywordListView";
            keywordListView.Size = new Size(371, 261);
            keywordListView.TabIndex = 1;
            keywordListView.UseCompatibleStateImageBehavior = false;
            keywordListView.AfterLabelEdit += keywordListView_AfterLabelEdit;
            keywordListView.SelectedIndexChanged += keywordListView_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 395);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 2;
            label2.Text = "论文列表";
            // 
            // paperListView
            // 
            paperListView.FullRowSelect = true;
            paperListView.Location = new Point(12, 418);
            paperListView.Name = "paperListView";
            paperListView.Size = new Size(371, 296);
            paperListView.TabIndex = 3;
            paperListView.UseCompatibleStateImageBehavior = false;
            paperListView.SelectedIndexChanged += paperListView_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(searchListView);
            groupBox1.Controls.Add(searchButton);
            groupBox1.Controls.Add(excludeBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(includeBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(389, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(647, 753);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "按关键词搜索";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 165);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 6;
            label5.Text = "搜索结果";
            // 
            // searchListView
            // 
            searchListView.FullRowSelect = true;
            searchListView.Location = new Point(6, 188);
            searchListView.Name = "searchListView";
            searchListView.Size = new Size(631, 559);
            searchListView.TabIndex = 5;
            searchListView.UseCompatibleStateImageBehavior = false;
            searchListView.SelectedIndexChanged += searchListView_SelectedIndexChanged;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(573, 26);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(64, 127);
            searchButton.TabIndex = 4;
            searchButton.Text = "搜索";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // excludeBox
            // 
            excludeBox.Location = new Point(96, 99);
            excludeBox.Multiline = true;
            excludeBox.Name = "excludeBox";
            excludeBox.ScrollBars = ScrollBars.Vertical;
            excludeBox.Size = new Size(471, 54);
            excludeBox.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 99);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 2;
            label4.Text = "排除关键词";
            // 
            // includeBox
            // 
            includeBox.Location = new Point(96, 29);
            includeBox.Multiline = true;
            includeBox.Name = "includeBox";
            includeBox.ScrollBars = ScrollBars.Vertical;
            includeBox.Size = new Size(471, 54);
            includeBox.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 32);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 0;
            label3.Text = "包含关键词";
            // 
            // includeButton
            // 
            includeButton.Enabled = false;
            includeButton.Location = new Point(213, 338);
            includeButton.Name = "includeButton";
            includeButton.Size = new Size(170, 34);
            includeButton.TabIndex = 5;
            includeButton.Text = "添加到包含关键词 >>";
            includeButton.UseVisualStyleBackColor = true;
            includeButton.Click += includeButton_Click;
            // 
            // excludeButton
            // 
            excludeButton.Enabled = false;
            excludeButton.Location = new Point(213, 378);
            excludeButton.Name = "excludeButton";
            excludeButton.Size = new Size(170, 34);
            excludeButton.TabIndex = 6;
            excludeButton.Text = "添加到排除关键词 >>";
            excludeButton.UseVisualStyleBackColor = true;
            excludeButton.Click += exludeButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(contentBox);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(keyWordBox);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(titleBox);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(1042, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(576, 750);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "预览";
            // 
            // contentBox
            // 
            contentBox.Location = new Point(6, 212);
            contentBox.Multiline = true;
            contentBox.Name = "contentBox";
            contentBox.ReadOnly = true;
            contentBox.ScrollBars = ScrollBars.Vertical;
            contentBox.Size = new Size(564, 532);
            contentBox.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 189);
            label9.Name = "label9";
            label9.Size = new Size(39, 20);
            label9.TabIndex = 4;
            label9.Text = "内容";
            // 
            // keyWordBox
            // 
            keyWordBox.Location = new Point(6, 132);
            keyWordBox.Multiline = true;
            keyWordBox.Name = "keyWordBox";
            keyWordBox.ReadOnly = true;
            keyWordBox.ScrollBars = ScrollBars.Vertical;
            keyWordBox.Size = new Size(564, 54);
            keyWordBox.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 109);
            label8.Name = "label8";
            label8.Size = new Size(99, 20);
            label8.TabIndex = 2;
            label8.Text = "包含的关键词";
            // 
            // titleBox
            // 
            titleBox.Location = new Point(6, 52);
            titleBox.Multiline = true;
            titleBox.Name = "titleBox";
            titleBox.ReadOnly = true;
            titleBox.ScrollBars = ScrollBars.Vertical;
            titleBox.Size = new Size(564, 54);
            titleBox.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 29);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 0;
            label7.Text = "标题";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 15);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 8;
            label6.Text = "添加关键词";
            // 
            // addBox
            // 
            addBox.Location = new Point(102, 12);
            addBox.Name = "addBox";
            addBox.Size = new Size(217, 27);
            addBox.TabIndex = 9;
            // 
            // addButton
            // 
            addButton.Location = new Point(325, 5);
            addButton.Name = "addButton";
            addButton.Size = new Size(58, 41);
            addButton.TabIndex = 10;
            addButton.Text = "添加";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // flushButton
            // 
            flushButton.Location = new Point(279, 720);
            flushButton.Name = "flushButton";
            flushButton.Size = new Size(93, 42);
            flushButton.TabIndex = 11;
            flushButton.Text = "刷新论文";
            flushButton.UseVisualStyleBackColor = true;
            flushButton.Click += flushButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Enabled = false;
            deleteButton.Location = new Point(12, 338);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(110, 34);
            deleteButton.TabIndex = 12;
            deleteButton.Text = "删除关键词";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1627, 769);
            Controls.Add(deleteButton);
            Controls.Add(flushButton);
            Controls.Add(addButton);
            Controls.Add(addBox);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(excludeButton);
            Controls.Add(includeButton);
            Controls.Add(groupBox1);
            Controls.Add(paperListView);
            Controls.Add(label2);
            Controls.Add(keywordListView);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Find&Select";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView keywordListView;
        private Label label2;
        private ListView paperListView;
        private GroupBox groupBox1;
        private Label label5;
        private ListView searchListView;
        private Button searchButton;
        private TextBox excludeBox;
        private Label label4;
        private TextBox includeBox;
        private Label label3;
        private Button includeButton;
        private Button excludeButton;
        private GroupBox groupBox2;
        private Label label6;
        private TextBox addBox;
        private Button addButton;
        private Button flushButton;
        private Button deleteButton;
        private TextBox contentBox;
        private Label label9;
        private TextBox keyWordBox;
        private Label label8;
        private TextBox titleBox;
        private Label label7;
    }
}