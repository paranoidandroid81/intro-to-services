var fileName = "somefile.txt";

var current = 0;

var path = Path.Join("data", fileName);

// if (File.Exists(path)) {
//     var content = File.ReadAllText(path);
//     current = int.Parse(content);
// } else {
//     Directory.CreateDirectory("data");
//     File.CreateText(path);
// }


while (true) {
    Thread.Sleep(3000);
    current = ++current;
    // File.WriteAllText(path, current.ToString());
    Console.WriteLine($"Wrote {current} at {DateTime.Now:t}");
}