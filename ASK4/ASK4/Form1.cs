using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;

namespace ASK4
{
    public partial class Form1 : Form
    {
        public string message;
        string[] dictionary_of_curses;

        public Form1()
        {
            dictionary_of_curses = File.ReadAllLines("D:/MOJE/Projekty/ASK/ASK4/ASK4/dictionary_of_curses.txt");
            InitializeComponent();
        }


        private string checking(string message)
        {
            message = message.Replace('ą', 'a');
            message = message.Replace('Ą', 'A');
            message = message.Replace('ć', 'c');
            message = message.Replace('Ć', 'C');
            message = message.Replace('ę', 'e');
            message = message.Replace('Ę', 'E');
            message = message.Replace('ł', 'l');
            message = message.Replace('Ł', 'L');
            message = message.Replace('ń', 'n');
            message = message.Replace('Ń', 'N');
            message = message.Replace('ó', 'o');
            message = message.Replace('Ó', 'O');
            message = message.Replace('ś', 's');
            message = message.Replace('Ś', 'S');
            message = message.Replace('ź', 'z');
            message = message.Replace('Ź', 'Z');
            message = message.Replace('ż', 'z');
            message = message.Replace('Ż', 'Z');
            for (int i = 0; i < dictionary_of_curses.Length; i++) {
                message = Regex.Replace(message, dictionary_of_curses[i], new string('*', dictionary_of_curses[i].Length), RegexOptions.IgnoreCase);
            }

            return message;
        }


        private string processing(string message)
        {
            string binary_message = "";
            string start_bit = "0";
            string stop_bit = "11";
            foreach (char c in message){
                string data_bit = Convert.ToString(Convert.ToInt32(c), 2).ToString();
                if (data_bit.Length < 8)
                {
                    data_bit = new string('0', 8 - data_bit.Length) + data_bit;
                }
                binary_message += start_bit + data_bit + stop_bit;
            }
            return binary_message;
        }


        private string regenerating(string binary_message)
        {
            string message = "";
            while (binary_message.Length > 0)
            {
                binary_message = binary_message.Remove(0, 1);                                                // <- usunięcie bitu startu
                message += Convert.ToChar(Convert.ToInt32(binary_message.Substring(0, 8), 2));
                binary_message = binary_message.Remove(0, 8);                                                // <- usunięcie bitów znaku
                binary_message = binary_message.Remove(0, 2);                                                // <- usunięcie bitu stopu
            }
            return message;
        }


        private void send_Click(object sender, EventArgs e)
        {
            message = sender_TB.Text;               // <- pobranie wiadomości z okna nadajnika
            message = checking(message);            // <- sprawdzenie czy wiadomość nie zawiera słów "grubych"
            message = processing(message);          // <- przetworzenie wiadomości do postaci łańcucha bitów
            chain_TB.Text = message;                // <- wypisanie łańcucha bitów w oknie
            message = regenerating(message);        // <- odtworzenie wiadomości z łańcucha bitów
            receiver_TB.Text = message;             // <- wypisanie odtworzonej wiadomości w oknie odbiornika
        }


        private void sender_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
