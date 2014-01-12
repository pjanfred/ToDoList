using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Aufgabe : INotifyPropertyChanged
    {
        public Aufgabe()
        {
            faelligkeit = DateTime.Now;
        }

        private string _name;
        public string name {
            get{
                return _name; 
            }
		    set
		    {
			    _name = value;
                NotifyPropertyChanged("name");
		    }
        }


        private DateTime? _faelligkeit;
        public DateTime? faelligkeit
        {
            get
            {
                return _faelligkeit;
            }
            set
            {
                _faelligkeit = value;
                NotifyPropertyChanged("faelligkeit");
            }
        }
        
        #region ---- INotifyPropertyChanged Implementierung ----
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
