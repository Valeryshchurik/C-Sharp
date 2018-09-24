namespace Corpus
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.wordintext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequenceintext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodesIntext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.myDictionaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDictionaryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 50);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1016, 22);
            this.textBox1.TabIndex = 13;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(587, 79);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(343, 527);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1095, 188);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(221, 107);
            this.button3.TabIndex = 15;
            this.button3.Text = "Открыть справку по тегам";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.word,
            this.code});
            this.dataGridView1.Location = new System.Drawing.Point(587, 79);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(481, 527);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wordintext,
            this.Frequenceintext,
            this.CodesIntext});
            this.dataGridView2.Location = new System.Drawing.Point(51, 84);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(443, 521);
            this.dataGridView2.TabIndex = 17;
            // 
            // wordintext
            // 
            this.wordintext.HeaderText = "Word";
            this.wordintext.Name = "wordintext";
            this.wordintext.Width = 200;
            // 
            // Frequenceintext
            // 
            this.Frequenceintext.HeaderText = "Frequence";
            this.Frequenceintext.Name = "Frequenceintext";
            this.Frequenceintext.ReadOnly = true;
            // 
            // CodesIntext
            // 
            this.CodesIntext.HeaderText = "Codes";
            this.CodesIntext.Name = "CodesIntext";
            this.CodesIntext.ReadOnly = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(447, 610);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(172, 34);
            this.button4.TabIndex = 18;
            this.button4.Text = "Слить в словарь";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1017, 30);
            this.button1.TabIndex = 19;
            this.button1.Text = "Добавить текстовый файл для обработки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // 
            // word
            // 
            this.word.HeaderText = "word";
            this.word.Name = "word";
            this.word.Width = 180;
            // 
            // code
            // 
            this.code.HeaderText = "codes";
            this.code.Name = "code";
            this.code.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.code.Width = 120;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1356, 693);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDictionaryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordintext;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequenceintext;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodesIntext;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewComboBoxColumn code;
        private System.Windows.Forms.BindingSource myDictionaryBindingSource;
    }
}