using System.Diagnostics;

namespace BLP_101_DonemSonuProjesi_OgrenciVeriSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region *****************   DonemSonuProjesi Tamamlanmış Hali   ****************** 
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n\n \u2554\u2550═════════════════════════════════════\u2557\n \u2551\t   ÖĞRENCİ NOT SİSTEMİ          ║\n \u255a══════════════════════════════════════\u255d\n");
                Console.ForegroundColor = ConsoleColor.Yellow;

                uint ogrenciAdet;

                while (true)
                {
                    Console.Write("\n\n → Öğrenci sayısını giriniz\t\t: ");
                    ogrenciAdet = uint.Parse(Console.ReadLine().Trim());

                    if (ogrenciAdet > 0)
                        break;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n HATA! Öğrenci sayısı '0' olamaz. Lütfen geçerli bir değer giriniz.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }

                ulong[] ogNo = new ulong[ogrenciAdet];
                uint[] ogVize = new uint[ogrenciAdet], ogFinal = new uint[ogrenciAdet], ogOrtalama = new uint[ogrenciAdet];
                string[] ogAd = new string[ogrenciAdet], ogSoyad = new string[ogrenciAdet], ogHarfNot = new string[ogrenciAdet];

                object[,] ogrenciVerileri = new object[ogrenciAdet, 7];

                uint sinifToplamNot = 0;

                for (int i = 0; i < ogrenciAdet; i++)
                {
                    Console.Write($"\n \u2192 #[{i + 1}] Öğrencinin numarasını giriniz\t: ");
                    ogNo[i] = ulong.Parse(Console.ReadLine().Trim());

                    Console.Write($"\n \u2192 #[{i + 1}] Öğrencinin adını giriniz\t: ");
                    ogAd[i] = Console.ReadLine().Trim();

                    Console.Write($"\n \u2192 #[{i + 1}] Öğrencinin soyadını giriniz\t: ");
                    ogSoyad[i] = Console.ReadLine().Trim();


                    while (true)
                    {
                    VizeNotu:

                        Console.Write($"\n \u2192 #[{i + 1}] Öğrencinin vize notunu giriniz\t: ");
                        ogVize[i] = uint.Parse(Console.ReadLine().Trim());

                        if (ogVize[i] <= 100)
                            goto FinalNotu;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nLütfen yalnızca [0-100] arasında bir değer giriniz.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto VizeNotu;
                        }
                    FinalNotu:

                        Console.Write($"\n \u2192 #[{i + 1}] Öğrencinin final notunu giriniz\t: ");
                        ogFinal[i] = uint.Parse(Console.ReadLine().Trim());

                        if (ogFinal[i] <= 100)
                            break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nLütfen yalnızca [0-100] arasında bir değer giriniz.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto FinalNotu;
                        }
                    }

                    Console.WriteLine("\n\n\u25AC▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\n");

                    ogOrtalama[i] = (ogVize[i] * 2 / 5) + (ogFinal[i] * 3 / 5);

                    sinifToplamNot += ogOrtalama[i];

                    if (ogOrtalama[i] >= 85)
                        ogHarfNot[i] = "AA";
                    else if (ogOrtalama[i] >= 75)
                        ogHarfNot[i] = "BA";
                    else if (ogOrtalama[i] >= 60)
                        ogHarfNot[i] = "BB";
                    else if (ogOrtalama[i] >= 50)
                        ogHarfNot[i] = "CB";
                    else if (ogOrtalama[i] >= 40)
                        ogHarfNot[i] = "CC";
                    else if (ogOrtalama[i] >= 30)
                        ogHarfNot[i] = "DC";
                    else if (ogOrtalama[i] >= 20)
                        ogHarfNot[i] = "DD";
                    else if (ogOrtalama[i] >= 10)
                        ogHarfNot[i] = "FD";
                    else if (ogOrtalama[i] >= 0)
                        ogHarfNot[i] = "FF";

                    for (int j = 0; j < ogrenciVerileri.GetLength(1);)
                    {
                        ogrenciVerileri[i, j] = ogNo[i]; j++;
                        ogrenciVerileri[i, j] = ogAd[i]; j++;
                        ogrenciVerileri[i, j] = ogSoyad[i]; j++;
                        ogrenciVerileri[i, j] = ogVize[i]; j++;
                        ogrenciVerileri[i, j] = ogFinal[i]; j++;
                        ogrenciVerileri[i, j] = ogOrtalama[i]; j++;
                        ogrenciVerileri[i, j] = ogHarfNot[i]; j++;
                    }

                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\n      ╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗ \n      ║\tNUMARA\t\t\tAD\t\tSOYAD\t\tVIZE NOTU\tFINAL NOTU\tORTALAMA\tHARF NOTU ║\n      \u255A═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════\u255d");
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                for (int i = 0; i < ogrenciVerileri.GetLength(0); i++)
                {

                    Console.Write("      ║");

                    for (int j = 0; j < ogrenciVerileri.GetLength(1); j++)
                    {
                        Console.Write("\t{1}\t", i + 1, ogrenciVerileri[i, j]);
                    }
                    Console.WriteLine("   ║\n      \u255a═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n\t\tSınıf Ortalaması\t:\t[ {0} ]\n\n\t\tEn yüksek not\t\t:\t[ {1} ]\n\n\t\tEn düşük not\t\t:\t[ {2} ]\n\n", (float)sinifToplamNot / (float)ogrenciAdet, ogOrtalama.Max(), ogOrtalama.Min());
                Console.ResetColor();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n HATA! Girdiğiniz değer çok uzundur. Lütfen tekrar deneyiniz");
                Console.ResetColor();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n HATA! Girdiğiniz değer uygun biçimde değildir. Lütfen tekrar deneyiniz");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBilinmeyen bir hata meydana geldi\nHatanın detaylarını görmek icin 'E' tuşuna basınız . . . ");
                char cevap = char.Parse(Console.ReadLine().Trim().ToUpper());
                Console.ResetColor();
                switch (cevap)
                {
                    case 'E':
                        Console.WriteLine("\nHata mesajı\t\t: {0}\n\nDetaylı hata mesajı\t: {2}\n\nHatanın oluştuğu tarih\t:\t{1}", ex.Message, DateTime.Now, ex.StackTrace);
                        break;
                    default:
                        break;
                }
            }

            #endregion

            #region İkinci yol : iki boyutlu diziyi doğrudan kullanarak
            //try
            //{
            //    Console.Write("Kac ogrenci kaydetmek istersiniz : ");
            //    uint ogrenciAdet = uint.Parse(Console.ReadLine().Trim());
            //    ulong sinifOrtalamasi = 0;

            //    object[,] ogVerileri = new object[ogrenciAdet, 7];
            //    ulong[] ogOrtalamaKiyaslama = new ulong[ogrenciAdet];

            //    for (int i = 0; i < ogVerileri.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < ogVerileri.GetLength(1);)
            //        {
            //            Console.Write($"#{i + 1} Ogrencinin numarasini giriniz : ");

            //            ogVerileri[i, j] = ulong.Parse(Console.ReadLine()); j++;
            //            Console.Write($"#{i + 1} Ogrencinin ismini giriniz : ");
            //            ogVerileri[i, j] = Console.ReadLine(); j++;
            //            Console.Write($"#{i + 1} Ogrencinin Soyadini giriniz : ");
            //            ogVerileri[i, j] = Console.ReadLine(); j++;

            //            while (true)
            //            {
            //                Console.Write($"#{i + 1} Ogrencinin Vize notunu giriniz : ");
            //                ogVerileri[i, j] = ulong.Parse(Console.ReadLine()); j++;

            //                Console.Write($"#{i + 1} Ogrencinin Final notunu giriniz : ");
            //                ogVerileri[i, j] = ulong.Parse(Console.ReadLine()); j++;
            //                if ((ulong)ogVerileri[i, j - 2] <= 100 && (ulong)ogVerileri[i, j - 1] <= 100)
            //                    break;
            //                else
            //                    Console.WriteLine("Lutfen sadece 0-100 arasi deger giriniz."); j -= 2;
            //            }
            //            ogVerileri[i, j] = (ulong)ogVerileri[i, j - 2] * 2 / 5 + (ulong)ogVerileri[i, j - 1] * 3 / 5;

            //            sinifOrtalamasi += (ulong)ogVerileri[i, j]; j++;

            //            if ((ulong)ogVerileri[i, j - 1] >= 85)
            //                ogVerileri[i, j] = "AA";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 75)
            //                ogVerileri[i, j] = "BA";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 60)
            //                ogVerileri[i, j] = "BB";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 50)
            //                ogVerileri[i, j] = "CB";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 40)
            //                ogVerileri[i, j] = "CC";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 30)
            //                ogVerileri[i, j] = "DC";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 20)
            //                ogVerileri[i, j] = "DD";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 10)
            //                ogVerileri[i, j] = "FD";
            //            else if ((ulong)ogVerileri[i, j - 1] >= 85)
            //                ogVerileri[i, j + 1] = "FF";

            //            j++;
            //        }
            //        Console.WriteLine("\n===============================================\n");
            //    }
            //    for (int i = 0; i < ogVerileri.GetLength(0); i++)
            //    {
            //        Console.WriteLine("\n\n");
            //        for (int j = 0; j < ogVerileri.GetLength(1); j++)
            //        {
            //            Console.Write($"\t{ogVerileri[i, j]}\t");
            //        }
            //        Console.WriteLine("\n\n");
            //    }


            //    for (int i = 0; i < ogrenciAdet; i++)
            //    {
            //        ogOrtalamaKiyaslama[i] = (ulong)ogVerileri[i, 5];
            //    }

            //    Console.WriteLine("\n\nSinif ortalamasi : {0}\n\nEn yuksek ortalama : {1}\n\nEn dusuk ortalama : {2}", sinifOrtalamasi / ogrenciAdet, ogOrtalamaKiyaslama.Max(), ogOrtalamaKiyaslama.Min());

            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("HATA lutfen dogru bicimde deger giriniz");
            //}
            //catch (OverflowException)
            //{
            //    Console.WriteLine("\nHATA girdiginiz deger siniri asmaktadir lutfen tekrar deneyiniz");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("\nBilinmeyen hata olustu\n\n\t{0}\n\t{1}", ex.Message, DateTime.Now);
            //    throw;
            //}
            #endregion

            #region Üçüncü yol : Birden fazla, tek boyutlu diziler kullanarak
            //try
            //{
            //    Console.Write("Kac ogrenci kaydetmek istersiniz : ");
            //    uint ogrenciAdet = uint.Parse(Console.ReadLine());
            //    ulong sinifOrtalamasi = 0;


            //    ulong[] ogrenciNo = new ulong[ogrenciAdet];
            //    uint[] ogrenciVize = new uint[ogrenciAdet], ogrenciFinal = new uint[ogrenciAdet], ogrenciOrtalama = new uint[ogrenciAdet];

            //    string[] ogrenciHarfNotu = new string[ogrenciAdet], ogrenciAd = new string[ogrenciAdet], ogrenciSoyad = new string[ogrenciAdet];

            //    for (int i = 0; i < ogrenciAdet; i++)
            //    {
            //        Console.Write($"{i + 1}.Ogrenci numarasini giriniz : ");
            //        ogrenciNo[i] = ulong.Parse(Console.ReadLine());

            //        Console.Write($"{i + 1}.Ogrencinin Adini Giriniz : ");
            //        ogrenciAd[i] = Console.ReadLine();

            //        Console.Write($"{i + 1}.Ogrencinin Soyadini Giriniz : ");
            //        ogrenciSoyad[i] = Console.ReadLine();

            //        while (true)
            //        {
            //            Console.Write($"{i + 1}.Ogrencinin Vize Notunu Giriniz : ");
            //            ogrenciVize[i] = uint.Parse(Console.ReadLine());

            //            Console.Write($"{i + 1}.Ogrencinin final Notunu Giriniz : ");
            //            ogrenciFinal[i] = uint.Parse(Console.ReadLine());

            //            if (ogrenciVize[i] <= 100 && ogrenciFinal[i] <= 100)
            //                break;
            //            else
            //                Console.WriteLine("Lütfen yalnıza 0-100 aralığında değer giriniz.");
            //        }
            //        Console.WriteLine("\n=============================================\n");
            //        ogrenciOrtalama[i] = (ogrenciVize[i] * 2 / 5) + (ogrenciFinal[i] * 3 / 5);

            //        sinifOrtalamasi += ogrenciOrtalama[i];

            //        if (ogrenciOrtalama[i] >= 85)
            //            ogrenciHarfNotu[i] = "AA";
            //        else if (ogrenciOrtalama[i] >= 75)
            //            ogrenciHarfNotu[i] = "BA";
            //        else if (ogrenciOrtalama[i] >= 60)
            //            ogrenciHarfNotu[i] = "BB";
            //        else if (ogrenciOrtalama[i] >= 50)
            //            ogrenciHarfNotu[i] = "CB";
            //        else if (ogrenciOrtalama[i] >= 40)
            //            ogrenciHarfNotu[i] = "CC";
            //        else if (ogrenciOrtalama[i] >= 30)
            //            ogrenciHarfNotu[i] = "DC";
            //        else if (ogrenciOrtalama[i] >= 20)
            //            ogrenciHarfNotu[i] = "DD";
            //        else if (ogrenciOrtalama[i] >= 10)
            //            ogrenciHarfNotu[i] = "FD";
            //        else if (ogrenciOrtalama[i] >= 0)
            //            ogrenciHarfNotu[i] = "FF";
            //    }
            //    for (int i = 0; i < ogrenciAdet; i++)
            //    {
            //        Console.WriteLine($"\n\n\t{ogrenciNo[i]}\t\t{ogrenciAd[i]}\t\t{ogrenciSoyad[i]}\t\t{ogrenciVize[i]}\t\t{ogrenciFinal[i]}\t\t{ogrenciOrtalama[i]}\t\t{ogrenciHarfNotu[i]}");
            //    }
            //    Console.WriteLine($"\n\n\n\t\tSinif Ortalamasi : {sinifOrtalamasi}\n\n\t\tEn yuksek not : {ogrenciOrtalama.Max()}\n\n\t\tEn dusuk not :{ogrenciOrtalama.Min()}");

            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("HATA lutfen dogru bicimde deger giriniz");
            //}
            //catch (OverflowException)
            //{
            //    Console.WriteLine("\nHATA girdiginiz deger siniri asmaktadir lutfen tekrar deneyiniz");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("\nBilinmeyen hata olustu\n\n\t{0}\n\t{1}", ex.Message, DateTime.Now);
            //    throw;
            //}
            #endregion

        }
    }
}
