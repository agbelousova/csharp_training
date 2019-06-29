using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail, detailsInfo;

        public ContactData(string lastName, string firstName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public ContactData()
        {
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (LastName == other.LastName)
            {
                return FirstName == other.FirstName;
            }
            return LastName == other.LastName;

        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName == other.LastName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return "name=" + LastName;
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            { if (allPhones != null)
                {
                    return allPhones;
                }
            else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;

            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;

            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone=="")
            {
                return "";
            }
            else
            {
               return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
            }
        }

        public string Company { get; set; }

        private string Clean(string phone)
        {
            if (phone == "" || phone == null)
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone, "[ -()]", "");
            }
        }

        public string DetailsInfo
        {
            get
            {
                if (detailsInfo != "")
                {
                    return detailsInfo;
                }
                else
                {
                    detailsInfo = "";

                    if (FirstName != "")
                    {
                        detailsInfo += FirstName + " ";
                    }

                    if (LastName != "")
                    {
                        detailsInfo += LastName + "\r\n";
                    }

                    if (Address != "")
                    {
                        detailsInfo += Address + "\r\n\r\n";
                    }

                    if (HomePhone != "")
                    {
                        detailsInfo += "H: " + Clean(HomePhone) + "\r\n";
                    }

                    if (MobilePhone != "")
                    {
                        detailsInfo += "M: " + Clean(MobilePhone) + "\r\n";
                    }

                    if (WorkPhone != "")
                    {
                        detailsInfo += "M: " + Clean(WorkPhone) + "\r\n";
                    }

                    if (Fax != "")
                    {
                        detailsInfo += "F: " + Clean(Fax) + "\r\n\r\n";
                    }

                    if (Email != "")
                    {
                        detailsInfo += Email + "\r\n";
                    }

                    if (Email2 != "")
                    {
                        detailsInfo += Email2 + "\r\n";
                    }

                    if (Email3 != "")
                    {
                        detailsInfo += Email3 + "\r\n";
                    }

                    return detailsInfo.Trim();
                }
            }

            set
            {
                detailsInfo = value;
            }
        }


        public ContactData(string detailsinfo)
        {
            DetailsInfo = detailsInfo;
        }
    }
}
