namespace News.Services
{
    public class Verify
    {
        public bool VerifyPhoneNumber(string number)
        {
            string isitdigit ="";
            for(int i = 1; i < number.Length; i++)
            {
                isitdigit += number[i];
            }
            long j = 0;
            bool result = long.TryParse(isitdigit, out j);
            string Phone = number;
            string temp = "";
            for (int i = 0; i < 2; i++)
            {
                temp += Phone[i];
            }
            if (temp == "09" && Phone.Length==11 && result==true)
            {
                return true;
            }
            return false;
        }
        public bool VerifyInsuranceNumber(long code)
        {
            string number=code.ToString();
            if(number.Length == 10 ) {
                return true;
            }
            return false;
        }
        public bool Verifystring(string input)
        {
            string isitdigit = input;
            long j = 0;
            bool result = long.TryParse(isitdigit, out j);
            if(result == true)
            {
                return true;
            }
            return false;
        }
        public List<string>ExtractNumber(string input)
        {
            List<string>list=new List<string>();
            string s = input;
            string[] subs = s.Split('/');
            foreach (var sub in subs)
            {
               list.Add(sub);
            }
            return list;
        }


    }
}
