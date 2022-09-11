using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlowerPot
{
    public class InfoAboutFlowers : INotifyPropertyChanged
    {
        private int selectedItemId;
        private string name;
        private string fullName;
        private string description;
        private string imageAdress;
        private string modelAdress;
        private decimal? cost;
        private string color;
        private string category;
        private decimal? amount;

        #region Конструкторы

        public InfoAboutFlowers(string fullName, string description, string imageAdress, string modelAdress, decimal? cost, string color, string category, decimal? amount)
        {
            this.selectedItemId = 0;
            this.name = "";
            this.fullName = fullName;
            this.description = description;
            this.imageAdress = imageAdress;
            this.modelAdress = modelAdress;
            this.cost = cost;
            this.color = color;
            this.amount = amount;
            this.category = category;
        }

        public InfoAboutFlowers(int id, string name, string fullName, string description, string imageAdress, string modelAdress, decimal? cost, string color, string category, decimal? amount)
        {
            this.selectedItemId = id;
            this.name = name;
            this.fullName = fullName;
            this.description = description;
            this.imageAdress = imageAdress;
            this.modelAdress = modelAdress;
            this.cost = cost;
            this.color = color;
            this.amount = amount;
            this.category = category;
        }
        public InfoAboutFlowers()
        {
            this.fullName = "";
            this.description = "";
            this.imageAdress = @"D:\git\FP\FlowerPot\3dmodels\default.png";
            this.modelAdress = @"D:\git\FP\FlowerPot\3dmodels\default.obj";
            this.color = "";
            this.cost = 0;
            this.amount = 0;
            this.category = "";
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                RaisePropertyChanged("FullName");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }
        public string ImageAdress
        {
            get { return imageAdress; }
            set
            {
                imageAdress = value;
                RaisePropertyChanged("ImageAdress");
            }
        }
        public string ModelAdress
        {
            get { return modelAdress; }
            set
            {
                modelAdress = value;
                RaisePropertyChanged("ModelAdress");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        public decimal? Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                RaisePropertyChanged("Cost");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }
        public decimal? Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                RaisePropertyChanged("Amount");
            }
        }
        public int SelectedItemId
        {
            get { return selectedItemId; }
            set
            {
                selectedItemId = value;
                RaisePropertyChanged("SelectedItemId");
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                RaisePropertyChanged("Category");
            }
        }
    }
    #endregion

}