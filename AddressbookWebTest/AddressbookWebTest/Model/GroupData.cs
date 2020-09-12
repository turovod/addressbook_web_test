using System;

namespace AddressbookWebTest
{
    public class GroupData : IEquatable<GroupData>
    {
        string name;
        string header;
        string footer;

        int rowModify;

        // Реализация интерфейса IEquatable для организации сравнения оъектов. По умолчанию объекты равны, если ссылки на 
        // один и тот же объект

        public bool Equals(GroupData other)
        {
            // Проверки по правилам хорошего кода
            if (this == other) // Если объекты равны, то и элементы равны
            {
                return true;
            }

            // Проверки по правилам хорошего кода
            if (this == null) // Если сравниваемый объект не существует, то точно не равны
            {
                return false;
            }

            if (this.Name == other.Name) // Сравниваем только по имени (правило сравнения)
            {
                return true;
            }

            return false;
        }

        public GroupData(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public string Header
        {
            get { return header; }

            set { header = value; }
        }

        public string Footer
        {
            get { return footer; }

            set { footer = value; }
        }

        public int RowModify
        {
            get { return rowModify; }

            set { rowModify = value; }
        }

    }
}
