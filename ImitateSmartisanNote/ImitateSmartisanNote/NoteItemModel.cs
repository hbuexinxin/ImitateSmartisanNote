using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitateSmartisanNote
{
    public class NoteItemModel : INotifyPropertyChanged
    {
        public NoteItemModel(string date, string time, string note)
        {
            this._date = date;
            this._time = time;
            this._note = note;

            this.UpdateDateTip();
            this.UpdateNoteTitle();
        }

        private string _date;
        private string _time;
        private string _note;

        private string _dateTip;
        private string _noteTitle;

        public string DateTip
        {
            get
            {
                return _dateTip;
            }

            private set
            {
                if (_dateTip != value)
                {
                    this.NotifyPropertyChanged(DateTip);
                    _dateTip = value;
                }
            }
        }

        public string NoteTitle
        {
            get
            {
                return _noteTitle;
            }

            private set
            {
                if (_noteTitle != value)
                {
                    this.NotifyPropertyChanged(NoteTitle);
                    _noteTitle = value;
                }
            }
        }

        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date != value)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");

                    UpdateDateTip();
                }
            }
        }

        public string Time
        {
            get
            {
                return _time;
            }

            set
            {
                if (_time != value)
                {
                    _time = value;
                    NotifyPropertyChanged("Time");

                    UpdateDateTip();
                }
            }
        }

        public string Note
        {
            get
            {
                return _note;
            }

            set
            {
                if (_note != value)
                {
                    _note = value;
                    NotifyPropertyChanged("Note");

                    UpdateNoteTitle();
                }
            }
        }

        private void UpdateDateTip()
        {
            this.DateTip = this.MakeDateTip();
        }

        private string MakeDateTip()
        {
            return string.Format("{0} {1}", this.Date , this.Time);
        }

        private void UpdateNoteTitle()
        {
            this.NoteTitle = MakeNoteTitle();
        }

        private string MakeNoteTitle()
        {
            return this.Note;
        }

        private void NotifyPropertyChanged(string strPropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
