using System;

namespace PermutationInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "tzzerqtbp";
            string s2 = "tdnrrwzvsejustvhfbkvelaknhevaiclvbmztesneiopikefqkldbkcurpdrdygitznrlougvvdbkfmmieabbfkhjyuypdwsndpsrxpijfbdqeppftnstoamejxkzbdoggtutdfdwowwpzgxuheenlhhjlkfczgnxaaarfuhytazijrscaxipbpijmeagvbiraarrtplrepbmkxorghulvavzolymufenahaqwzdxfpayrirkggekdnopldumwqtaffrbtnilkijioyoziskzwlgbbwyhjfdplzeqjfultfmzlvvvuwoyxcvpxndfdvubxtofgwyctrgbctervycysuqifklrjtjjtvqydyeiuejhasftvpmizeewsmsrpgovlmnfmmrjpvcidvkzdwfrjgwnmbbyivylhtplvjfmuizkbffabzwgybvlcsocgcozbwwwhjcqiicspgtwrcuglyzkehaegsiaaasshcyyabvvusdbwxrdcvjuyquceoqamamiaagobfihfqdadcqqeoczfwshygvqecephfkfpobfftmtsrvrodjveddbubjjxifotlrwazxsltimojcwobvoepdqvqqoqnvvtaypgyrkltwizguzuncoauodpqugytcovzftcmefemlhnrceuokmzgenysfdsgtkbdgtezxomdlzrgojhzcarimplzxudrrbeqcffcpuyautqqqyugpqmcmgbrcyvolowgogjtdiijkfixepgudnotvsyhxrdqmhapwfkxpljlosvxpxkhbgkajwihwvduvrecsqoeyajmxpgibdqqpyhoxmssnnqyyjxfymbftwvgsxfrfwkxqpfxzjnoxrenidkophmlyucliufognokldhityonbprtqzztqhsewevqdjponmarnzubmhmjfzyffoanbrqklalyupkhsypaczenlsffreirzxmzzraxxlxuqbmzjuxeudwztekvqftwrzdxozeokrwbihccjwwxyzwcmqjeaubsmsldxzmwcmjpyoakyrguztdjorzryuxoagaxoiqipgigdbejixzdejsmeebtwzmfynykboxewzfnegcbucmcqvcpueztyckdjewvegqdygcewsqpeqitmfuuyhbiulgqoylwtrvoqthyirkwkngexemwlmuowizyuqliqoseelkfobgamxevjviwccncgfpdanvalzvsxzumnxkzxvpeoblgpzkrtppycjbpuxleodrtjfhtdlqndbjcwrupgelnkcdgakacvxudfypkfcgtahdtvqvwzcjuctwnpeyybcrlhkhnrsygwgqzacryqzwubjznrrbndewluuecxitjnlbmdusvjtiqpcbdmclhquualxmbdjgimenqcqzmpwhda";
            Console.WriteLine(CheckInclusion(s1, s2));
        }
        static bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;
            int[] r1 = new int[26];
            int[] r2 = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                r1[s1[i] - 'a']++;
                r2[s2[i] - 'a']++;
            }
            if (IsSameRecord(r1, r2))
                return true;
            int li = 1, hi = s1.Length;
            while (hi < s2.Length)
            {
                r2[s2[li - 1] - 'a']--;
                r2[s2[hi] - 'a']++;
                if (IsSameRecord(r1, r2))
                    return true;
                li++;
                hi++;
            }
            return false;
        }

        static bool IsSameRecord(int[] r1, int[] r2)
        {
            for (int i = 0; i < r1.Length; i++)
                if (r1[i] != r2[i])
                    return false;
            return true;
        }
    }
}
