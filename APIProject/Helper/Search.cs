using CommonModel;
using System;

namespace APIProject.Helper
{
    public class Search : ISearch
    {
        public ResumeSearch SearchPattern(string hardSkills, string softSkills,string resumeText)
        {
            return null;
            //var arrHardSkills = hardSkills.Split(',');
            //var arrsoftSkills = softSkills.Split(',');

            //int M = pat.Length;
            //int resumeLength = resumeText.Length;

            ///* A loop to slide pat one by one */
            //for (int i = 0; i <= resumeLength - M; i++)
            //{
            //    int j;

            //    /* For current index i, check for pattern
            //    match */
            //    for (j = 0; j < M; j++)
            //        if (txt[i + j] != pat[j])
            //            break;

            //    // if pat[0...M-1] = txt[i, i+1, ...i+M-1]
            //    if (j == M)
            //        Console.WriteLine("Pattern found at index " + i);
            //}
        }
    }
}
