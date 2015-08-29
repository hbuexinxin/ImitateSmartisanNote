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
        public NoteItemModel(string dateTip, string noteTitle)
        {
            this._dateTip = dateTip;
            this._noteTitle = noteTitle;
        }


        private string _dateTip;
        private string _noteTitle;

        public string DateTip
        {
            get
            {
                return _dateTip;
            }

            set
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

            set
            {
                if (_noteTitle != value)
                {
                    this.NotifyPropertyChanged(NoteTitle);
                    _noteTitle = value;
                }
            }
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
