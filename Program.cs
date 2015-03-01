using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LetsDoThis
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "סתם";
            string[] alpha = new string[] { "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט", "י", "כ", "ל", "מ", "נ", "ס", "ע", "פ", "צ", "ק", "ר", "ש", "ת", "ץ", "ך", "ם", "ן" };
            string path = @"c:\Users\user\Desktop\TOOOOOOOV\Shura_tahtona\includes\json1\";
            string[] poli = new string[] { "Netanyahu", "IsaacHerzog", "tzipilivni", "NaftaliBennett", "YairLapid", "Moshekahalon", "zehavagalon", "DeryArye", "AvigdorLiberman", "137409609701165", "173196886046831", "166156570202888", "212547315512949", "620206311338749", "AviDichter1", "829660960390410", "156632191145120", "224562257709477", "davidamsalemjerusalem", "174411199282819", "EllibenDahan", "erelmargalit", "GermanYeshAtid", "207139259326193", "404314496289809", "jakilevi2013", "meircoh", "MichaeliMerav", "617957021581571", "MichalBiran", "520086018021432", "142479632494944", "MKIlanGilon", "mottiyogev", "NachmanShai", "NissanSlomiansky", "OfirAkunis", "oritstrook", "612784452070209", "154570404606299", "rontzkiavi", "201172239926506", "438831352866459", "102997256411052", "steinitzyuval50", "tamarzandberg", "297207456997968", "TzipiHotovely", "394242203948130", "341448679281672", "YossiYonah", "YuliEdelstein", "237683826350051", "DanonDanny", "katzisraellikud", "MFeiglin", "118410851589072", "ShellyYachimovich", "281431865311442", "442386732471209", "195437940588631", "sharongal100", "aamarhamad", "102155496619137", "ForerOded", "625040900863570", "Bezazelsmotrich", "639391266187801", "318718848205174", "MichaelsonSonLion", "Officialbaruchmarzel", "OferYeshAtid", "350522538451081", "457794627605948", "371426819606751", "402936269773132", "LevyYeshAtid", "SternElazar", "PninaTamano", "377452172353770", "boaztoporovsky", "Trajtenberg", "MKHasson", "389464081230676", "SvetlovaKsenia", "zohirbhlol", "YoavGallant", "EliElalouf", "AmbassadorOren", "sbyifat", "450583275090800", "1000293466651925", "632771873441351", "DabushMeretz", "AymanOdeh1975", "dovhanin", "348254355276420", "1578176972413229", "258598010822055" };
            string newpath = @"c:\Users\user\Desktop\TOOOOOOOV\Shura_tahtona\includes\json3\" + word + ".txt";
            for (int i1 = 0; i1 < 22; i1++)
            {
                for (int i2 = 0; i2 < 22; i2++)
                {
                    for (int i3 = 0; i3 < 26; i3++)
                    {
                        word = "";
                        word = alpha[i1] + alpha[i2] + alpha[i3];
                        Console.WriteLine(word);

                        int count = 0;
                        using (FileStream fs = File.Create(newpath))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine("[");
                                for (int i = 0; i < poli.Length; i++)
                                {
                                    string temppath = path + poli[i] + @"\" + word + ".txt";
                                    //Console.WriteLine(temppath);
                                    if (File.Exists(temppath))
                                    {
                                        if (count == 0)
                                        {
                                            sw.WriteLine("{\"id\":\"" + poli[i] + "\",\"resarr\":");
                                        }
                                        else
                                        {
                                            sw.WriteLine(",{\"id\":\"" + poli[i] + "\",\"resarr\":");
                                        }
                                        count = count + 1;
                                        using (StreamReader sr = File.OpenText(temppath))
                                        {
                                            string s = "";
                                            bool foundbug = false;
                                            while ((s = sr.ReadLine()) != null)
                                            {

                                                for (int j = 0; j < s.Length; j++)
                                                {
                                                    if (j < s.Length - 1)
                                                    {
                                                        if ((s[j] == ']') && (s[j + 1] == '['))
                                                        {
                                                            foundbug = true;
                                                            break;
                                                        }
                                                    }

                                                }
                                                if (foundbug)
                                                {
                                                    sw.WriteLine("]");
                                                    break;
                                                }
                                                //Console.WriteLine(s);
                                                sw.WriteLine(s);
                                            }
                                        }
                                        sw.WriteLine("}");
                                    }

                                }
                                sw.WriteLine("]");
                            }

                        }

                    }
                }
            }

        }
    }
}
