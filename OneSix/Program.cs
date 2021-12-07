using System;
using System.IO;
using System.Linq;
using PKHeX.Core;

namespace OneSix
{
    class Program
    {
        private static readonly char[] aiueo =
            ("あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよわをん" +
            "アイウエオカキクケコサシスセソタチステトナニヌネノハヒフヘホマミムメモヤユヨワヲン").ToCharArray();

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: OneSix.exeにPK4ファイルをドラッグ＆ドロップしてください。");
                Console.ReadLine();
                return;
            }

            var inputPath = args[0];

            // 平文のPK4ファイルを読み込み
            FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            byte[] PK4Data = new byte[fs.Length];
            fs.Read(PK4Data, 0, (int)fs.Length);
            fs.Dispose();

            // 第4世代のデータとして読み込み
            var pokemon = new PK4(PK4Data);
            var oldName = pokemon.Nickname;
            Console.WriteLine($"{oldName}の新しいニックネームを検索しています。");

            // 3文字の名前を列挙
            var names = from c1 in aiueo
                        from c2 in aiueo
                        from c3 in aiueo
                        select new string(new char[] { c1, c2, c3});

            // 末尾が0x16で終わる名前を検索
            var newName = names
                .Where(name => IsEndWith16h(name, pokemon))
                .FirstOrDefault();

            if (newName == null)
            {
                Console.WriteLine("いいニックネームが見つかりませんでした。別のポケモンで試してみてください。");
            }
            else
            {
                Console.WriteLine($"「{oldName}」というのかい？贅沢な名だね。今からお前の名前は「{newName}」だ。");
            }
            Console.ReadLine();
        }

        static private bool IsEndWith16h(string name, PK4 pokemon)
        {
            pokemon.Nickname = name;
            var encrypted = pokemon.EncryptedBoxData;
            return encrypted[^1] == 0x16;
        }
    }
}

