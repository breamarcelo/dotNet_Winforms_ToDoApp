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
using System.Text.Json.Nodes;
using System.IO;

namespace TodoApp
{
    public partial class Form1 : Form
    {
        public class ToDoItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public bool Completed { get; set; }
        }
        int itemId = 1;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;

            var readFile = File.ReadAllText("J:\\ARCHIVOS\\dev\\dotNet\\TodoApp\\todoList.json");
            var readJson = JsonNode.Parse(readFile).AsArray().ToArray();

            ToDoItem[] todoItems = new ToDoItem[readJson.Length];
            int i = 0;
            foreach (var item in readJson)
            {
                var todItem = JsonSerializer.Deserialize<ToDoItem>(item);
                todoItems[i] = todItem;
                i++;
            }

            foreach (var item in todoItems)
            {
                Panel newItemPanel = new Panel();
                newItemPanel.BackColor = Color.Red;
                newItemPanel.Width = 500;
                newItemPanel.Height = 100;
                newItemPanel.Left = 50;
                if(itemId == 1)
                {
                    newItemPanel.Top = 25;
                } else
                {
                    newItemPanel.Top = itemId * 125;
                }

                TextBox titleText = new TextBox();
                titleText.Text = this.itemId.ToString() + item.Title;
                titleText.Left = 0; titleText.Top = 0;
                newItemPanel.Controls.Add(titleText);

                TextBox descText = new TextBox();
                descText.Text = item.Description;
                descText.Left = 0; descText.Top = 25;
                newItemPanel.Controls.Add(descText);

                panel3.Controls.Add(newItemPanel);

                itemId++;
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible=true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Hide completed";
            }
            else
            {
                checkBox1.Text = "Show completed";
            }
        }
    }
}
