using CodeFirstEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CodeFirstEF
{
    /// <summary>
    /// Логика взаимодействия для NoteEdit.xaml
    /// </summary>
    public partial class NoteEdit : Window
    {
        public Note Note { get; set; } = new Note();
        public NoteEdit(Note n)
        {
            InitializeComponent();
            DataContext = new NoteEditViewmodel(n, this);
        }
        public void Close(Note note)
        {
            Note = note;
            Close();
        }
    }
}
