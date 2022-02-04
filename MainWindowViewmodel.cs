using CodeFirstEF.Models;
using Microsoft.EntityFrameworkCore;
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
    public class MainWindowViewmodel: OnPropertyChangedHandler
    {
        public MainWindowViewmodel()
        {
            //using (var ctx = new CodeFirstEFContext())
            //{
            //    ctx.Categories.Add(new Category { Type = "Rate" });
            //    ctx.Categories.Add(new Category { Type = "Earning" });
            //    ctx.SaveChanges();
            //}
            Refresh.Execute(1);
        }
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        public Note selected
        {
            get=> s;
            set 
            {
                s = value;
                OnPropertyChanged(nameof(selected));
            }
        }

            Note s;
        public ICommand Add => new RelayCommand(o =>
        {
            using (var ctx = new CodeFirstEFContext())
            {
                NoteEdit win = new NoteEdit(new Note());
                if (win.ShowDialog() != null)
                {
                    if (win.Note != null)
                    {
                        var note = win.Note;
                        note.category = ctx.Categories.First(o => o.Id == win.Note.category.Id);
                        ctx.Notes.Add(note);                        
                        ctx.SaveChanges();
                        Refresh.Execute(1);
                        OnPropertyChanged(nameof(Notes));
                    }
                }
            }
            
        });
        public ICommand Delete => new RelayCommand(o =>
        {
            using (var ctx = new CodeFirstEFContext())
            {
                ctx.Notes.Remove(ctx.Notes.First(o => o.Id ==  selected.Id));
                ctx.SaveChanges();
                Refresh.Execute(1);
            }
        }, o=> selected!=null);
        public ICommand Refresh => new RelayCommand(o =>
        {
            var list = new List<Note>();
            using (var ctx = new CodeFirstEFContext())
            {
                foreach (var item in ctx.Notes.Include(n=>n.category))
                {
                    list.Add(item);
                }
                var categories = ctx.Categories;
            }
            Notes = new ObservableCollection<Note>(list);
            OnPropertyChanged(nameof(Notes));
        });
    }
}
