using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using IEnumerable;



namespace TodoApp
{
    public partial class UserControl1 : UserControl
    {
        public class ToDoItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public bool Completed { get; set; }
        }
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var toDoItem = new ToDoItem
            {
                Title = textBox1.Text,
                Description = textBox2.Text,
                Completed = false

            };

            string fileName = "todoList.json";
            string jsonString = JsonSerializer.Serialize(toDoItem);

            File.WriteAllText(fileName, jsonString);

        /*    Panel p1 = new Panel();
            p1.BackColor = Color.Red;
            p1.Width = 100;
            p1.Height = 50;
            p1.Left = 100;
            p1.Top = itemId * 75;
            TextBox t1 = new TextBox();
            t1.Text = "Hello World! " + this.itemId.ToString();
            p1.Controls.Add(t1);
            panel3.Controls.Add(p1);

            itemId++; */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var parentPanel = this.Parent as Panel;
            parentPanel.Visible = false;
        }
    }
}
