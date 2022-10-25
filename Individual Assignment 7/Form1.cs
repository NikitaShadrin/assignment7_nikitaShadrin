using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_Assignment_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> correct = new List<string>();
            List<int> incorrect = new List<int>();
            int counter = 0;
            string incorrAnswers = "";
            string[] corrAnswers = {"B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A"};
            foreach (string line in File.ReadAllLines("C:\\Users\\ADMIN\\source\\repos\\Individual Assignment 7\\Exam Answers.txt"))
            {
                string answer = line.Split(' ').Last();
                
                if(answer == corrAnswers[counter])
                {
                    correct.Add(answer);
                }
                else
                {
                    incorrect.Add(counter + 1);
                }

                counter++;
            }

            if (incorrect.Count > 0)
            {
                foreach (int question in incorrect)
                {
                    incorrAnswers += question + ", ";
                    System.Console.WriteLine(question);
                }
                incorrAnswers = incorrAnswers.Remove(incorrAnswers.Length - 1);
            }



            if (correct.Count > 14)
            {
                label1.Text = ("Congratulations! You passed the exam! \n" +
                    "You answered " + correct.Count + " questions correctly! \n");
                if (incorrect.Count > 0)
                {
                     label1.Text += ("You only answered question(s) " + incorrAnswers + " incorrectly");
                }

            } else
            {
                label1.Text = ("You didn't pass the exam! \n" +
                    "You only got " + correct.Count + " answers correct out of 20 \n" +
                    "You answered the following questions incorrectly: " + incorrAnswers);
            }
        }
    }
}
