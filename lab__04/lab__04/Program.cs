using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Concurrent;

namespace lab__04
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //wybieram ja poniewaz posiada funkcja ktora pozwala na sprawdzenie czy rekord o podanym stringu juz istnieje i moge wykonac operacje zmiany wartosci 
            przyklad istnieje key: a value : 1 gdy program bedzie chcial dodac key:a value:1 po raz kolejny zamiast tego zmieni value na 2 
            */
            var by_firstletters = new ConcurrentDictionary<string, int>();
            /* Moge narpierw dodac wiersze a nastepnie petla for zrobic order by aby posegregowac po value */
            var by_ordersize = new ConcurrentDictionary<string, long>();
            /* Moge narpierw dodac wiersze a nastepnie petla for zrobic order by aby posegregowac po Key */
            var by_names = new ConcurrentDictionary<string, string>();
            /* Do przechowywania wierszy podzielonych na "galezie" np: image,audio...  wykorzystuje IEnumerable  */
            Bytypes by_types = new Bytypes();
            /* Do przechowywania wierszy podzielonych na "galezie" np: image,audio...  wykorzystuje IEnumerable  */
            ByExtensions by_extensions = new ByExtensions();
            /* Do przechowywania wierszy podzielonych na "galezie" np: image,audio...  wykorzystuje IEnumerable  */
            Bysizez by_sizes = new Bysizez();


            //Trzeba zmienic rootpath w zaleznosci gdzie chcemy skanowac
            string rootpath = @"C:\xampp";
            string[] dirs = Directory.GetDirectories(rootpath);
            string[] files = Directory.GetFiles(rootpath);
            //nodes
            int count_dir = 0;
            int count_files = 0;
            long size_dir = 0;

            //by types
            int by_types_count_images = 0;
            int by_types_count_audio = 0;
            int by_types_count_video = 0;
            int by_types_count_document = 0;
            int by_types_count_other = 0;

            long by_types_total_size_images = 0;
            long by_types_total_size_audio = 0;
            long by_types_total_size_video = 0;
            long by_types_total_size_document = 0;
            long by_types_total_size_other = 0;

            long by_types_avgsize_images = 0;
            long by_types_avgsize_audio = 0;
            long by_types_avgsize_video = 0;
            long by_types_avgsize_document = 0;
            long by_types_avgsize_other = 0;

            long by_types_minsize_images = 0;
            long by_types_minsize_audio = 0;
            long by_types_minsize_video = 0;
            long by_types_minsize_document = 0;
            long by_types_minsize_other = 0;

            long by_types_maxsize_images = 0;
            long by_types_maxsize_audio = 0;
            long by_types_maxsize_video = 0;
            long by_types_maxsize_document = 0;
            long by_types_maxsize_other = 0;

            //by_extensions

            int by_extensions_count_jpg = 0;
            int by_extensions_count_png = 0;
            int by_extensions_count_gif = 0;
            int by_extensions_count_doc = 0;
            int by_extensions_count_txt = 0;
            int by_extensions_count_mp3 = 0;
            int by_extensions_count_other = 0;


            long by_extensions_total_size_jpg = 0;
            long by_extensions_total_size_png = 0;
            long by_extensions_total_size_gif = 0;
            long by_extensions_total_size_doc = 0;
            long by_extensions_total_size_txt = 0;
            long by_extensions_total_size_mp3 = 0;
            long by_extensions_total_size_other = 0;


            long by_extensions_avgsize_jpg = 0;
            long by_extensions_avgsize_png = 0;
            long by_extensions_avgsize_gif = 0;
            long by_extensions_avgsize_doc = 0;
            long by_extensions_avgsize_txt = 0;
            long by_extensions_avgsize_mp3 = 0;
            long by_extensions_avgsize_other = 0;

            long by_extensions_minsize_jpg = 0;
            long by_extensions_minsize_png = 0;
            long by_extensions_minsize_gif = 0;
            long by_extensions_minsize_doc = 0;
            long by_extensions_minsize_txt = 0;
            long by_extensions_minsize_mp3 = 0;
            long by_extensions_minsize_other = 0;

            long by_extensions_maxsize_jpg = 0;
            long by_extensions_maxsize_png = 0;
            long by_extensions_maxsize_gif = 0;
            long by_extensions_maxsize_doc = 0;
            long by_extensions_maxsize_txt = 0;
            long by_extensions_maxsize_mp3 = 0;
            long by_extensions_maxsize_other = 0;
            //by sizes
            int by_sizes_count_E1Kb = 0;
            int by_sizes_count_E1Kb1Mb = 0;
            int by_sizes_count_E1Mb1Gb = 0;
            int by_sizes_count_H1Gb = 0;


            long by_sizes_total_size_E1Kb = 0;
            long by_sizes_total_size_E1Kb1Mb = 0;
            long by_sizes_total_size_E1Mb1Gb = 0;
            long by_sizes_total_size_H1Gb = 0;


            long by_sizes_avgsize_E1Kb = 0;
            long by_sizes_avgsize_E1Kb1Mb = 0;
            long by_sizes_avgsize_E1Mb1Gb = 0;
            long by_sizes_avgsize_H1Gb = 0;


            long by_sizes_minsize_E1Kb = 0;
            long by_sizes_minsize_E1Kb1Mb = 0;
            long by_sizes_minsize_E1Mb1Gb = 0;
            long by_sizes_minsize_H1Gb = 0;


            long by_sizes_maxsize_E1Kb = 0;
            long by_sizes_maxsize_E1Kb1Mb = 0;
            long by_sizes_maxsize_E1Mb1Gb = 0;
            long by_sizes_maxsize_H1Gb = 0;

            //counts

            foreach (string dir in dirs)
            {
                count_dir = count_dir + 1;
                var infodic = new DirectoryInfo(dir);
                foreach (var size in infodic.GetFiles())
                {
                    count_files = count_files + 1;
                    size_dir = size_dir + size.Length;
                }


            }

            long size_dir_files = 0;
            size_dir_files = size_dir;

            foreach (string file in files)
            {
                count_files = count_files + 1;
                var info = new FileInfo(file);
                size_dir_files = size_dir_files + file.Length;

                string extencionfind = info.Extension;
                switch (extencionfind)
                {
                    case ".jpg":
                        by_extensions_count_jpg = by_extensions_count_jpg + 1;
                        by_extensions_total_size_jpg = by_extensions_total_size_jpg + info.Length;
                        if (by_extensions_minsize_jpg >= info.Length || by_extensions_minsize_jpg == 0)
                        {
                            by_extensions_minsize_jpg = info.Length;
                        }
                        if (by_extensions_maxsize_jpg <= info.Length || by_extensions_maxsize_jpg == 0)
                        {
                            by_extensions_maxsize_jpg = info.Length;
                        }
                        break;
                    case ".png":
                        by_extensions_count_png = by_extensions_count_png + 1;
                        by_extensions_total_size_png = by_extensions_total_size_png + info.Length;
                        if (by_extensions_minsize_png >= info.Length || by_extensions_minsize_png == 0)
                        {
                            by_extensions_minsize_png = info.Length;
                        }
                        if (by_extensions_maxsize_png <= info.Length || by_extensions_maxsize_png == 0)
                        {
                            by_extensions_maxsize_png = info.Length;
                        }
                        break;
                    case ".gif":
                        by_extensions_count_gif = by_extensions_count_gif + 1;
                        by_extensions_total_size_gif = by_extensions_total_size_gif + info.Length;
                        if (by_extensions_minsize_gif >= info.Length || by_extensions_minsize_gif == 0)
                        {
                            by_extensions_minsize_gif = info.Length;
                        }
                        if (by_extensions_maxsize_gif <= info.Length || by_extensions_maxsize_gif == 0)
                        {
                            by_extensions_maxsize_gif = info.Length;
                        }
                        break;
                    case ".doc":
                        by_extensions_count_doc = by_extensions_count_doc + 1;
                        by_extensions_total_size_doc = by_extensions_total_size_doc + info.Length;
                        if (by_extensions_minsize_doc >= info.Length || by_extensions_minsize_doc == 0)
                        {
                            by_extensions_minsize_doc = info.Length;
                        }
                        if (by_extensions_maxsize_doc <= info.Length || by_extensions_maxsize_doc == 0)
                        {
                            by_extensions_maxsize_doc = info.Length;
                        }
                        break;
                    case ".txt":
                        by_extensions_count_txt = by_extensions_count_txt + 1;
                        by_extensions_total_size_txt = by_extensions_total_size_txt + info.Length;
                        if (by_extensions_minsize_txt >= info.Length || by_extensions_minsize_txt == 0)
                        {
                            by_extensions_minsize_txt = info.Length;
                        }
                        if (by_extensions_maxsize_txt <= info.Length || by_extensions_maxsize_txt == 0)
                        {
                            by_extensions_maxsize_txt = info.Length;
                        }
                        break;

                    case ".mp3":
                        by_extensions_count_mp3 = by_extensions_count_mp3 + 1;
                        by_extensions_total_size_mp3 = by_extensions_total_size_mp3 + info.Length;
                        if (by_extensions_minsize_mp3 >= info.Length || by_extensions_minsize_mp3 == 0)
                        {
                            by_extensions_minsize_mp3 = info.Length;
                        }
                        if (by_extensions_maxsize_mp3 <= info.Length || by_extensions_maxsize_mp3 == 0)
                        {
                            by_extensions_maxsize_mp3 = info.Length;
                        }
                        break;
                    default:
                        by_extensions_count_other = by_extensions_count_other + 1;
                        by_extensions_total_size_other = by_extensions_total_size_other + info.Length;
                        if (by_extensions_minsize_other >= info.Length || by_extensions_minsize_other == 0)
                        {
                            by_extensions_minsize_other = info.Length;
                        }
                        if (by_extensions_maxsize_other <= info.Length || by_extensions_maxsize_other == 0)
                        {
                            by_extensions_maxsize_other = info.Length;
                        }
                        break;

                }

                string test = findtypeoffile(info.Extension);
                switch (test)
                {
                    case "image":
                        by_types_count_images = by_types_count_images + 1;
                        by_types_total_size_images = by_types_total_size_images + info.Length;
                        if (by_types_minsize_images >= info.Length || by_types_minsize_images == 0)
                        {
                            by_types_minsize_images = info.Length;
                        }
                        if (by_types_maxsize_images <= info.Length || by_types_maxsize_images == 0)
                        {
                            by_types_maxsize_images = info.Length;
                        }
                        break;
                    case "audio":
                        by_types_count_audio = by_types_count_audio + 1;
                        by_types_total_size_audio = by_types_total_size_audio + info.Length;
                        if (by_types_minsize_audio >= info.Length || by_types_minsize_audio == 0)
                        {
                            by_types_minsize_audio = info.Length;
                        }
                        if (by_types_maxsize_audio <= info.Length || by_types_maxsize_audio == 0)
                        {
                            by_types_maxsize_audio = info.Length;
                        }
                        break;
                    case "video":
                        by_types_count_video = by_types_count_video + 1;
                        by_types_total_size_video = by_types_total_size_video + info.Length;
                        if (by_types_minsize_video >= info.Length || by_types_minsize_video == 0)
                        {
                            by_types_minsize_video = info.Length;
                        }
                        if (by_types_maxsize_video <= info.Length || by_types_maxsize_video == 0)
                        {
                            by_types_maxsize_video = info.Length;
                        }
                        break;
                    case "document":
                        by_types_count_document = by_types_count_document + 1;
                        by_types_total_size_document = by_types_total_size_document + info.Length;
                        if (by_types_minsize_document >= info.Length || by_types_minsize_document == 0)
                        {
                            by_types_minsize_document = info.Length;
                        }
                        if (by_types_maxsize_document <= info.Length || by_types_maxsize_document == 0)
                        {
                            by_types_maxsize_document = info.Length;
                        }
                        break;
                    case "other":
                        by_types_count_other = by_types_count_other + 1;
                        by_types_total_size_other = by_types_total_size_other + info.Length;
                        if (by_types_minsize_other >= info.Length || by_types_minsize_other == 0)
                        {
                            by_types_minsize_other = info.Length;
                        }
                        if (by_types_maxsize_other <= info.Length || by_types_maxsize_other == 0)
                        {
                            by_types_maxsize_other = info.Length;
                        }
                        break;

                }
                long sizedfiles = info.Length;
                if (sizedfiles < 1024)
                {
                    by_sizes_count_E1Kb = by_sizes_count_E1Kb + 1;
                    by_sizes_total_size_E1Kb = by_sizes_total_size_E1Kb + info.Length;
                    if (by_sizes_minsize_E1Kb >= info.Length || by_sizes_minsize_E1Kb == 0)
                    {
                        by_sizes_minsize_E1Kb = info.Length;
                    }
                    if (by_sizes_maxsize_E1Kb <= info.Length || by_sizes_maxsize_E1Kb == 0)
                    {
                        by_sizes_maxsize_E1Kb = info.Length;
                    }

                }
                else if (1024 < sizedfiles && sizedfiles < 1048576)
                {
                    by_sizes_count_E1Kb1Mb = by_sizes_count_E1Kb1Mb + 1;
                    by_sizes_total_size_E1Kb1Mb = by_sizes_total_size_E1Kb1Mb + info.Length;
                    if (by_sizes_minsize_E1Kb1Mb >= info.Length || by_sizes_minsize_E1Kb1Mb == 0)
                    {
                        by_sizes_minsize_E1Kb1Mb = info.Length;
                    }
                    if (by_sizes_maxsize_E1Kb1Mb <= info.Length || by_sizes_maxsize_E1Kb1Mb == 0)
                    {
                        by_sizes_maxsize_E1Kb1Mb = info.Length;
                    }

                }
                else if (1048576 < sizedfiles && sizedfiles < 1073741824)
                {
                    by_sizes_count_E1Mb1Gb = by_sizes_count_E1Mb1Gb + 1;
                    by_sizes_total_size_E1Mb1Gb = by_sizes_total_size_E1Mb1Gb + info.Length;
                    if (by_sizes_minsize_E1Mb1Gb >= info.Length || by_sizes_minsize_E1Mb1Gb == 0)
                    {
                        by_sizes_minsize_E1Mb1Gb = info.Length;
                    }
                    if (by_sizes_maxsize_E1Mb1Gb <= info.Length || by_sizes_maxsize_E1Mb1Gb == 0)
                    {
                        by_sizes_maxsize_E1Mb1Gb = info.Length;
                    }

                }
                else if (sizedfiles > 1073741824)
                {
                    by_sizes_count_H1Gb = by_sizes_count_H1Gb + 1;
                    by_sizes_total_size_H1Gb = by_sizes_total_size_H1Gb + info.Length;
                    if (by_sizes_minsize_H1Gb >= info.Length || by_sizes_minsize_H1Gb == 0)
                    {
                        by_sizes_minsize_H1Gb = info.Length;
                    }
                    if (by_sizes_maxsize_H1Gb <= info.Length || by_sizes_maxsize_H1Gb == 0)
                    {
                        by_sizes_maxsize_H1Gb = info.Length;
                    }

                }

                string nazwa_pliku = (info.Name.ToLower());
                string rozmiar_pliku = ConvertBytesToKB(info.Length);
                by_firstletters.AddOrUpdate(nazwa_pliku[0].ToString(), 1, (id, count) => count + 1);
                string rozmiar_i_sciezka = ($"{rozmiar_pliku}     {info.FullName}");
                by_names.TryAdd(nazwa_pliku, rozmiar_i_sciezka);
                by_ordersize.TryAdd(info.Name, info.Length);

            }
            if (by_types_count_images == 0)
            {
                by_types_avgsize_images = 0;
            }
            else
            { by_types_avgsize_images = by_types_total_size_images / by_types_count_images; }
            if (by_types_count_audio == 0)
            {
                by_types_avgsize_audio = 0;
            }
            else { by_types_avgsize_audio = by_types_total_size_audio / by_types_count_audio; }

            if (by_types_count_video == 0)
            {
                by_types_avgsize_video = 0;
            }
            else { by_types_avgsize_video = by_types_total_size_video / by_types_count_video; }
            if (by_types_count_document == 0)
            {
                by_types_avgsize_document = 0;
            }
            else { by_types_avgsize_document = by_types_total_size_document / by_types_count_document; }
            if (by_types_count_other == 0)
            {
                by_types_avgsize_other = 0;
            }
            else { by_types_avgsize_other = by_types_total_size_other / by_types_count_other; }


            by_types.AddImage("image", by_types_count_images.ToString(), ConvertBytesToKB(by_types_total_size_images), ConvertBytesToKB(by_types_avgsize_images), ConvertBytesToKB(by_types_minsize_images), ConvertBytesToKB(by_types_maxsize_images));
            by_types.AddAudio("audio", by_types_count_audio.ToString(), ConvertBytesToKB(by_types_total_size_audio), ConvertBytesToKB(by_types_avgsize_audio), ConvertBytesToKB(by_types_minsize_audio), ConvertBytesToKB(by_types_maxsize_audio));
            by_types.AddVideo("video", by_types_count_video.ToString(), ConvertBytesToKB(by_types_total_size_video), ConvertBytesToKB(by_types_avgsize_video), ConvertBytesToKB(by_types_minsize_video), ConvertBytesToKB(by_types_maxsize_video));
            by_types.AddDocument("document", by_types_count_document.ToString(), ConvertBytesToKB(by_types_total_size_document), ConvertBytesToKB(by_types_avgsize_document).ToString(), ConvertBytesToKB(by_types_minsize_document), ConvertBytesToKB(by_types_maxsize_document));
            by_types.AddOther("other", by_types_count_other.ToString(), ConvertBytesToKB(by_types_total_size_other), ConvertBytesToKB(by_types_avgsize_other), ConvertBytesToKB(by_types_minsize_other), ConvertBytesToKB(by_types_maxsize_other));

            if (by_extensions_count_jpg == 0)
            {
                by_extensions_avgsize_jpg = 0;
            }
            else
            { by_extensions_avgsize_jpg = by_extensions_total_size_jpg / by_extensions_count_jpg; }
            if (by_extensions_count_png == 0)
            {
                by_extensions_avgsize_png = 0;
            }
            else { by_extensions_avgsize_png = by_extensions_total_size_png / by_extensions_count_png; }

            if (by_extensions_count_gif == 0)
            {
                by_extensions_avgsize_gif = 0;
            }
            else { by_extensions_avgsize_gif = by_extensions_total_size_gif / by_extensions_count_gif; }
            if (by_extensions_count_doc == 0)
            {
                by_extensions_avgsize_doc = 0;
            }
            else { by_extensions_avgsize_doc = by_extensions_total_size_doc / by_extensions_count_doc; }
            if (by_extensions_count_txt == 0)
            {
                by_extensions_avgsize_txt = 0;
            }
            else { by_extensions_avgsize_txt = by_extensions_total_size_txt / by_extensions_count_txt; }
            if (by_extensions_count_mp3 == 0)
            {
                by_extensions_avgsize_mp3 = 0;
            }
            else { by_extensions_avgsize_mp3 = by_extensions_total_size_mp3 / by_extensions_count_mp3; }
            if (by_extensions_count_other == 0)
            {
                by_extensions_avgsize_other = 0;
            }
            else { by_extensions_avgsize_other = by_extensions_total_size_other / by_extensions_count_other; }

            by_extensions.AddJpg("jpg", by_extensions_count_jpg.ToString(), ConvertBytesToKB(by_extensions_total_size_jpg), ConvertBytesToKB(by_extensions_avgsize_jpg), ConvertBytesToKB(by_extensions_minsize_jpg), ConvertBytesToKB(by_extensions_maxsize_jpg));
            by_extensions.AddPng("png", by_extensions_count_png.ToString(), ConvertBytesToKB(by_extensions_total_size_png), ConvertBytesToKB(by_extensions_avgsize_png), ConvertBytesToKB(by_extensions_minsize_png), ConvertBytesToKB(by_extensions_maxsize_png));
            by_extensions.AddGif("gif", by_extensions_count_gif.ToString(), ConvertBytesToKB(by_extensions_total_size_gif), ConvertBytesToKB(by_extensions_avgsize_gif), ConvertBytesToKB(by_extensions_minsize_gif), ConvertBytesToKB(by_extensions_maxsize_gif));
            by_extensions.AddDoc("doc", by_extensions_count_doc.ToString(), ConvertBytesToKB(by_extensions_total_size_doc), ConvertBytesToKB(by_extensions_avgsize_doc).ToString(), ConvertBytesToKB(by_extensions_minsize_doc), ConvertBytesToKB(by_extensions_maxsize_doc));
            by_extensions.AddTxt("txt", by_extensions_count_txt.ToString(), ConvertBytesToKB(by_extensions_total_size_txt), ConvertBytesToKB(by_extensions_avgsize_txt).ToString(), ConvertBytesToKB(by_extensions_minsize_txt), ConvertBytesToKB(by_extensions_maxsize_txt));
            by_extensions.AddMp3("mp3", by_extensions_count_mp3.ToString(), ConvertBytesToKB(by_extensions_total_size_mp3), ConvertBytesToKB(by_extensions_avgsize_mp3).ToString(), ConvertBytesToKB(by_extensions_minsize_mp3), ConvertBytesToKB(by_extensions_maxsize_mp3));
            by_extensions.AddOther("other", by_extensions_count_other.ToString(), ConvertBytesToKB(by_extensions_total_size_other), ConvertBytesToKB(by_extensions_avgsize_other), ConvertBytesToKB(by_extensions_minsize_other), ConvertBytesToKB(by_extensions_maxsize_other));

            if (by_sizes_count_E1Kb == 0)
            {
                by_sizes_avgsize_E1Kb = 0;
            }
            else
            { by_sizes_avgsize_E1Kb = by_sizes_total_size_E1Kb / by_sizes_count_E1Kb; }
            if (by_sizes_count_E1Kb1Mb == 0)
            {
                by_sizes_avgsize_E1Kb1Mb = 0;
            }
            else { by_sizes_avgsize_E1Kb1Mb = by_sizes_total_size_E1Kb1Mb / by_sizes_count_E1Kb1Mb; }

            if (by_sizes_count_E1Mb1Gb == 0)
            {
                by_sizes_avgsize_E1Mb1Gb = 0;
            }
            else { by_sizes_avgsize_E1Mb1Gb = by_sizes_total_size_E1Mb1Gb / by_sizes_count_E1Mb1Gb; }

            if (by_sizes_count_H1Gb == 0)
            {
                by_sizes_avgsize_H1Gb = 0;
            }
            else { by_sizes_avgsize_H1Gb = by_sizes_total_size_H1Gb / by_sizes_count_H1Gb; }
            by_sizes.AddL1Kb(". <= 1KB", by_sizes_count_E1Kb.ToString(), ConvertBytesToKB(by_sizes_total_size_E1Kb), ConvertBytesToKB(by_sizes_avgsize_E1Kb), ConvertBytesToKB(by_sizes_minsize_E1Kb), ConvertBytesToKB(by_sizes_maxsize_E1Kb));
            by_sizes.AddE1Kb("1KB < . <= 1MB", by_sizes_count_E1Kb1Mb.ToString(), ConvertBytesToKB(by_sizes_total_size_E1Kb1Mb), ConvertBytesToKB(by_sizes_avgsize_E1Kb1Mb), ConvertBytesToKB(by_sizes_minsize_E1Kb1Mb), ConvertBytesToKB(by_sizes_maxsize_E1Kb1Mb));
            by_sizes.AddE1Mb1Gb("1MB < . <= 1GB", by_sizes_count_E1Mb1Gb.ToString(), ConvertBytesToKB(by_sizes_total_size_E1Mb1Gb), ConvertBytesToKB(by_sizes_avgsize_E1Mb1Gb), ConvertBytesToKB(by_sizes_minsize_E1Mb1Gb), ConvertBytesToKB(by_sizes_maxsize_E1Mb1Gb));
            by_sizes.AddH1Gb("1GB < .", by_sizes_count_H1Gb.ToString(), ConvertBytesToKB(by_sizes_total_size_H1Gb), ConvertBytesToKB(by_sizes_avgsize_H1Gb).ToString(), ConvertBytesToKB(by_sizes_minsize_H1Gb), ConvertBytesToKB(by_sizes_maxsize_H1Gb));



            Console.WriteLine($"Nodes:");
            Console.WriteLine($"\t\t [count]  [total size]");
            Console.WriteLine($"  Directories:\t   {count_dir}      {ConvertBytesToKB(size_dir)}");
            Console.WriteLine($"  Files:\t   {count_files}     {ConvertBytesToKB(size_dir_files)}");
            Console.WriteLine($"\n");
            Console.WriteLine($"Files:");
            Console.WriteLine($"  By types:");
            Console.WriteLine($"\t\t  [count]    [total size]   [avg size]    [min size]    [max size]");
            foreach (string row in by_types.Image)
            {
                if (row != "image")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_types.Audio)
            {
                if (row != "audio")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_types.Video)
            {
                if (row != "video")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_types.Document)
            {
                if (row != "document")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"   {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_types.Other)
            {
                if (row != "other")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine();
            Console.WriteLine($"  By extensions:");
            Console.WriteLine($"\t\t  [count]    [total size]   [avg size]    [min size]    [max size]");
            foreach (string row in by_extensions.Jpg)
            {
                if (row != "jpg")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_extensions.Png)
            {
                if (row != "png")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_extensions.Gif)
            {
                if (row != "gif")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_extensions.Doc)
            {
                if (row != "doc")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_extensions.Txt)
            {
                if (row != "txt")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_extensions.Mp3)
            {
                if (row != "mp3")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_extensions.Other)
            {
                if (row != "other")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}        "); }
                }
                else { Console.Write($"      {row} \t    "); }
            }

            Console.WriteLine();
            Console.WriteLine($"  By sizes:");
            Console.WriteLine($"\t\t  [count]    [total size]   [avg size]    [min size]      [max size]");
            foreach (string row in by_sizes.E1Kb)
            {
                if (row != ". <= 1KB")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}          "); }
                }
                else { Console.Write($"       {row}    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_sizes.E1Kb1Mb)
            {
                if (row != "1KB < . <= 1MB")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}         "); }
                }
                else { Console.Write($" {row}    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_sizes.E1Mb1Gb)
            {
                if (row != "1MB < . <= 1GB")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}            ");
                    }
                    else
                    { Console.Write($"{row}         "); }
                }
                else { Console.Write($" {row}    "); }
            }
            Console.WriteLine("");
            foreach (string row in by_sizes.H1Gb)
            {
                if (row != "1GB < .")
                {
                    if (row == "0Kb")
                    {
                        Console.Write($"{row}             ");
                    }
                    else
                    { Console.Write($"{row}           "); }
                }
                else { Console.Write($"     {row} \t   "); }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"  Counts by first leter:");
            var sortedFiles = new string[by_firstletters.Count];
            var count = by_firstletters.Count - 1;
            foreach (var file in by_firstletters.OrderBy(x => x.Value))
            {
                sortedFiles[count--] = file.Key;

            }
            var sortedvalues = new int[by_firstletters.Count];
            var count1 = by_firstletters.Count - 1;
            foreach (var file in by_firstletters.OrderBy(x => x.Value))
            {
                sortedvalues[count1--] = file.Value;

            }


            Console.Write($"\t");
            foreach (var display in sortedFiles)
            {
                Console.Write($" {display}  ");
            }
            Console.WriteLine();
            Console.Write($"\t");
            foreach (var display in sortedvalues)
            {
                Console.Write($" {display}  ");
            }
            var sortedbynames = new string[by_names.Count];
            var count_names = 0;
            foreach (var file in by_names.OrderBy(x => x.Key))
            {
                sortedbynames[count_names++] = file.Key;

            }
            Console.WriteLine("\n");
            Console.WriteLine("   Ordered by name:");
            Console.WriteLine($"\t \t \t \t \t \t    [size]    [path]  ");

            foreach (var display in sortedbynames)
            {
                // Console.WriteLine(display);
                foreach (var disp in by_names)
                {
                    //  Console.WriteLine(disp);
                    if (display == disp.Key)
                    {


                        Console.Write($" \t \t {display.PadRight(35)}");
                        Console.Write($"{disp.Value}");
                        Console.WriteLine();
                        break;
                    }

                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("   Ordered by sizes (from biggest):");
            Console.WriteLine($"\t \t \t \t \t [size]    ");

            var sortedordervalues = new long[by_ordersize.Count];
            var count_order_values = by_ordersize.Count - 1;
            foreach (var file in by_ordersize.OrderBy(x => x.Value))
            {
                sortedordervalues[count_order_values--] = file.Value;

            }
            foreach (var display in sortedordervalues)
            {
                // Console.WriteLine(display);
                foreach (var disp in by_ordersize)
                {
                    //  Console.WriteLine(disp);
                    if (display == disp.Value)
                    {
                        Console.Write($"      {disp.Key.PadRight(35)}");
                        Console.Write($"{ConvertBytesToKB(disp.Value)}");
                        Console.WriteLine();
                        break;
                    }

                }
            }
            Console.ReadKey();
        }
        static string findtypeoffile(string extencion)
        {
            string[] image = new string[] { ".png", ".webp", ".jpg", ".gif", ".tiff" };
            string[] audio = new string[] { ".ogg", ".mp3" };
            string[] video = new string[] { ".mkv", ".mp4", ".webm" };
            string[] document = new string[] { ".txt", ".doc", ".docx", ".xml", ".xlmx" };

            string exd = extencion.ToLower();
            if (image.Any(exd.Contains))
            {
                return "image";
            }
            else if (audio.Any(exd.Contains))
            {
                return "audio";
            }
            else if (video.Any(exd.Contains))
            {
                return "video";
            }
            else if (document.Any(exd.Contains))
            {
                return "document";
            }
            else
            {
                return "other";
            }
        }
        static string ConvertBytesToKB(long bytes)
        {
            double wynik_KB = Math.Round((bytes / 1024f), 2);
            if (wynik_KB > 1024)
            {
                double wynik_MB = Math.Round(((bytes / 1024f) / 1024f), 2);
                if (wynik_MB > 1024)
                {
                    double wynik_GB = Math.Round((((bytes / 1024f) / 1024f) / 1024f), 2);
                    return wynik_GB + "GB";
                }
                else { return wynik_MB + "MB"; }

            }
            else
            {
                return wynik_KB + "Kb";
            }


        }
    }



    public class Bytypes : IEnumerable
    {
        // Private members.
        private List<What_typed> what_typeds = new List<What_typed>();

        // Public methods.
        public void AddImage(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Image });
        }

        public void AddAudio(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Audio });
        }

        public void AddVideo(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Video });
        }

        public void AddDocument(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Document });
        }
        public void AddOther(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Other });
        }



        public IEnumerator GetEnumerator()
        {
            foreach (What_typed theWhat_typed in what_typeds)
            {
                yield return theWhat_typed.Name;
            }
        }

        // Public members.
        public IEnumerable Image
        {
            get { return What_typedsForType(What_typed.TypeEnum.Image); }
        }

        public IEnumerable Audio
        {
            get { return What_typedsForType(What_typed.TypeEnum.Audio); }
        }
        public IEnumerable Video
        {
            get { return What_typedsForType(What_typed.TypeEnum.Video); }
        }

        public IEnumerable Document
        {
            get { return What_typedsForType(What_typed.TypeEnum.Document); }
        }
        public IEnumerable Other
        {
            get { return What_typedsForType(What_typed.TypeEnum.Other); }
        }



        // Private methods.
        private IEnumerable What_typedsForType(What_typed.TypeEnum type)
        {
            foreach (What_typed theWhat_typed in what_typeds)
            {
                if (theWhat_typed.Type == type)
                {
                    yield return theWhat_typed.Name;
                    yield return theWhat_typed.Count;
                    yield return theWhat_typed.Totalsize;
                    yield return theWhat_typed.Avgsize;
                    yield return theWhat_typed.Minsize;
                    yield return theWhat_typed.Maxsize;
                }
            }
        }

        // Private class.
        private class What_typed
        {
            public enum TypeEnum { Image, Audio, Video, Document, Other }

            public string Name { get; set; }
            public string Count { get; set; }
            public string Totalsize { get; set; }
            public string Avgsize { get; set; }
            public string Minsize { get; set; }
            public string Maxsize { get; set; }
            public TypeEnum Type { get; set; }
        }
    }





    public class ByExtensions : IEnumerable
    {
        // Private members.
        private List<What_typed> what_typeds = new List<What_typed>();

        // Public methods.
        public void AddJpg(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Jpg });
        }

        public void AddPng(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Png });
        }

        public void AddGif(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Gif });
        }

        public void AddDoc(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Doc });
        }
        public void AddTxt(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Txt });
        }
        public void AddMp3(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Mp3 });
        }
        public void AddOther(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.Other });
        }



        public IEnumerator GetEnumerator()
        {
            foreach (What_typed theWhat_typed in what_typeds)
            {
                yield return theWhat_typed.Name;
            }
        }

        // Public members.
        public IEnumerable Jpg
        {
            get { return What_typedsForType(What_typed.TypeEnum.Jpg); }
        }

        public IEnumerable Png
        {
            get { return What_typedsForType(What_typed.TypeEnum.Png); }
        }
        public IEnumerable Gif
        {
            get { return What_typedsForType(What_typed.TypeEnum.Gif); }
        }

        public IEnumerable Doc
        {
            get { return What_typedsForType(What_typed.TypeEnum.Doc); }
        }
        public IEnumerable Txt
        {
            get { return What_typedsForType(What_typed.TypeEnum.Txt); }
        }
        public IEnumerable Mp3
        {
            get { return What_typedsForType(What_typed.TypeEnum.Mp3); }
        }
        public IEnumerable Other
        {
            get { return What_typedsForType(What_typed.TypeEnum.Other); }
        }



        // Private methods.
        private IEnumerable What_typedsForType(What_typed.TypeEnum type)
        {
            foreach (What_typed theWhat_typed in what_typeds)
            {
                if (theWhat_typed.Type == type)
                {
                    yield return theWhat_typed.Name;
                    yield return theWhat_typed.Count;
                    yield return theWhat_typed.Totalsize;
                    yield return theWhat_typed.Avgsize;
                    yield return theWhat_typed.Minsize;
                    yield return theWhat_typed.Maxsize;
                }
            }
        }

        // Private class.
        private class What_typed
        {
            public enum TypeEnum { Jpg, Png, Gif, Doc, Txt, Mp3, Other }

            public string Name { get; set; }
            public string Count { get; set; }
            public string Totalsize { get; set; }
            public string Avgsize { get; set; }
            public string Minsize { get; set; }
            public string Maxsize { get; set; }
            public TypeEnum Type { get; set; }
        }
    }
    public class Bysizez : IEnumerable
    {
        // Private members.
        private List<What_typed> what_typeds = new List<What_typed>();

        // Public methods.
        public void AddL1Kb(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.E1Kb });
        }

        public void AddE1Kb(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.E1Kb1Mb });
        }

        public void AddE1Mb1Gb(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.E1Mb1Gb });
        }

        public void AddH1Gb(string name, string count, string totalsize, string avgsize, string minsize, string maxsize)
        {
            what_typeds.Add(new What_typed { Name = name, Count = count, Totalsize = totalsize, Avgsize = avgsize, Minsize = minsize, Maxsize = maxsize, Type = What_typed.TypeEnum.H1Gb });
        }




        public IEnumerator GetEnumerator()
        {
            foreach (What_typed theWhat_typed in what_typeds)
            {
                yield return theWhat_typed.Name;
            }
        }

        // Public members.
        public IEnumerable E1Kb
        {
            get { return What_typedsForType(What_typed.TypeEnum.E1Kb); }
        }

        public IEnumerable E1Kb1Mb
        {
            get { return What_typedsForType(What_typed.TypeEnum.E1Kb1Mb); }
        }
        public IEnumerable E1Mb1Gb
        {
            get { return What_typedsForType(What_typed.TypeEnum.E1Mb1Gb); }
        }

        public IEnumerable H1Gb
        {
            get { return What_typedsForType(What_typed.TypeEnum.H1Gb); }
        }




        // Private methods.
        private IEnumerable What_typedsForType(What_typed.TypeEnum type)
        {
            foreach (What_typed theWhat_typed in what_typeds)
            {
                if (theWhat_typed.Type == type)
                {
                    yield return theWhat_typed.Name;
                    yield return theWhat_typed.Count;
                    yield return theWhat_typed.Totalsize;
                    yield return theWhat_typed.Avgsize;
                    yield return theWhat_typed.Minsize;
                    yield return theWhat_typed.Maxsize;
                }
            }
        }

        // Private class.
        private class What_typed
        {
            public enum TypeEnum { E1Kb, E1Kb1Mb, E1Mb1Gb, H1Gb }

            public string Name { get; set; }
            public string Count { get; set; }
            public string Totalsize { get; set; }
            public string Avgsize { get; set; }
            public string Minsize { get; set; }
            public string Maxsize { get; set; }
            public TypeEnum Type { get; set; }
        }
    }
}