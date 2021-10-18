namespace Lab2
{
    class Student
    {
        public string lastName { get; set; }
        public int examFirst { get; set; }
        public int examSecond { get; set; }
        public int examThird { get; set; }
        public bool redDiploma { get; set; }
        public string city { get; set; }
        public bool needHousing { get; set; }


        public Student(string lastName, int examFirst, int examSecond, int examThird,bool redDiploma, string city, bool needHousing)
        {
            this.lastName = lastName;
            this.examFirst = examFirst;
            this.examSecond = examSecond;
            this.examThird = examThird;
            this.redDiploma = redDiploma;
            this.city = city;
            this.needHousing = needHousing;
        }
    }
}
