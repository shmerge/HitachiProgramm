using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HitachiProgramm
{
    class File
    {
        private string fileName;
        
        public File()
        {
            this.fileName = "RportByCountry.csv";
        }

        public string getFileName()
        {
            return this.fileName;
        }

        public void addRecord(string country, double averageScore, double maxScore, 
            string maxScorePerson, double minScore, string minScorePerson, int recordCount)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName, true))
                {
                    double medianScore = (maxScore + minScore) / 2; 
                    
                    file.WriteLine(country + "," + averageScore + "," + medianScore + "," + maxScore + "," + maxScorePerson + "," + minScore + ","
                    + minScorePerson + "," + recordCount);
                }           
            }
            catch (IOException ex)
            {
                throw new ApplicationException("There is a problem with input values.");
            }
        }

        public string[] sort()
        {
            string[] response = {"The input parameters are bad"};
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@fileName);
                for (int k = 0; k < lines.Length - 1; k++)
                {
                    for (int j = 1; j < lines.Length - 1; j++)
                    {
                        string[] field1 = lines[j].Split(',');
                        string[] field2 = lines[lines.Length - 1 - j].Split(',');
                        
                        if (field1[0].Contains(field2[0])) 
                        {
                            if (Int32.Parse(field1[1]) < Int32.Parse(field2[1]))
                            {
                                swap(j, j + 1, lines);
                            } 
                        } /*else if (!field1[0].Contains(field2[0]))
                        {
                            if (Int32.Parse(field1[1]) < Int32.Parse(field2[1]))
                            {
                                swap(j, j + 1, lines);
                            }
                        }*/
                        


                    }
                }
                return lines;
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        public void swap(int index1, int index2, string[] arr)
        {
            string temp;
            temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        public void reWrite()
        {
            System.IO.File.WriteAllLines(@fileName, sort());
        }
    }
}
