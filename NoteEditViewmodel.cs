using CodeFirstEF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFbase;
namespace CodeFirstEF
{
    public class NoteEditViewmodel:OnPropertyChangedHandler
    {
        public Note note { get; set; } = new Note();
        NoteEdit window;
        public NoteEditViewmodel(Note note, NoteEdit noteEdit)
        {
            this.note = note;
            if (note!=new Note())
            {                
                Title.Item = note.Title;
                Summ.Item = note.Summ;
                
                Date = note.Date;
            }
            window = noteEdit;
            Date = DateTime.Now;

            using (var ctx = new CodeFirstEFContext())
            {
                Categories = new ObservableCollection<Category>();
                ctx.Categories.ToList().ForEach(c => Categories.Add(c));
            }
        }
        public DateTime Date
        {
            get => d;
            set
            {
                d = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        DateTime d;
        public ChangingItem<string> Title { get; set; } = new ChangingItem<string>();
        public ChangingItem<decimal> Summ { get; set; } = new ChangingItem<decimal>();
        public ChangingItem<string> Category { get; set; } = new ChangingItem<string>();
        public List<string> categories => new List<string>
        {
            "Rate",
            "Earning"
        };

        public ObservableCollection<Category> Categories { get; set; }
        public ICommand Save => new RelayCommand(o =>
        {
            
            using (var ctx = new CodeFirstEFContext())
            {
                //note.Date = Date;
                //note.Summ = Summ.Item;
                //note.Title = Title.Item;
                note.category = ctx.Categories.First(o => o.Id == note.category.Id); 
                window.Close(note);
            }
            
        });
        public ICommand Cancel => new RelayCommand(o =>
        {
            window.Close(note); 
        });
    }
}
