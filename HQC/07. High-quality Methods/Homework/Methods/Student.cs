﻿namespace Methods
{
    using System;

    public class Student
    {
        private const string FirstNameNullOrEmptyException = "First name can not be null or empty.";
        private const string LastNameNullOrEmptyException = "Last name can not be null or empty.";
        private const string DateOfBirthNullOrEmptyException = "Date of birth can not be null or empty.";
        private const string DateOfBirthFormatException = "Date of birth must be in format DD.MM.YYYY.";

        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string otherInfo;

        public Student(string firstName, string lastName, string birthDate, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(FirstNameNullOrEmptyException);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(LastNameNullOrEmptyException);
                }

                this.lastName = value;
            }
        }

        // birth date encapsulated - uses DateTime but reveals only string
        public string BirthDate
        {
            get
            {
                return this.birthDate.ToString();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(DateOfBirthNullOrEmptyException);
                }

                DateTime dateOfBirth;

                if (DateTime.TryParse(value, out dateOfBirth))
                {
                    this.birthDate = dateOfBirth;
                }
                else
                {
                    throw new ArgumentException(DateOfBirthFormatException);
                }
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                this.otherInfo = value;
            }
        }

        // to be older means to have a smaller date of birth
        public bool IsOlderThan(Student otherStudent)
        {
            var isOlderThanOtherStudent = this.birthDate < otherStudent.birthDate;

            return isOlderThanOtherStudent;
        }
    }
}