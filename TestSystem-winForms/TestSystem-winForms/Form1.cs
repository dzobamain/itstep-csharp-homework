using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestSystem_winForms
{
    public partial class Form1 : Form
    {
        private string[] questions = { "What is the capital of France?", "How many continents are there in the world?", "What is the highest mountain?" };

        private string[][] answers = {
            new string[] { "Paris", "Berlin", "Barselona" },
            new string[] { "5", "6", "7" },
            new string[] { "Everest", "Test", "Ararat" }
        };

        private int[] right_answers = { 0, 1, 0 };

        private int currentQuestion = 0;
        private int correctAnswersCount = 0;

        public Form1()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (currentQuestion < questions.Length)
            {
                labelQuestion.Text = questions[currentQuestion];
                radioButton1.Text = answers[currentQuestion][0];
                radioButton2.Text = answers[currentQuestion][1];
                radioButton3.Text = answers[currentQuestion][2];

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;

                progressBar.Value = (currentQuestion + 1) * 100 / questions.Length;
            }
            else
            {
                MessageBox.Show("Number of correct answers: " + correctAnswersCount + "/" + questions.Length);
                progressBar.Value = 0;
                currentQuestion = 0;
                correctAnswersCount = 0;

                labelQuestion.Text = questions[currentQuestion];
                radioButton1.Text = answers[currentQuestion][0];
                radioButton2.Text = answers[currentQuestion][1];
                radioButton3.Text = answers[currentQuestion][2];
            }
        }

        private void CheckAnswers()
        {
            if (radioButton1.Checked && right_answers[currentQuestion] == 0 ||
                radioButton2.Checked && right_answers[currentQuestion] == 1 ||
                radioButton3.Checked && right_answers[currentQuestion] == 2)
            {
                correctAnswersCount++;
            }
        }

        private void buttonNext_Click_1(object sender, EventArgs e)
        {
            CheckAnswers();
            currentQuestion++;
            LoadQuestion();
        }
    }
}

