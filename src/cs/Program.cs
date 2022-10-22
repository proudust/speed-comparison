using System;
using System.Buffers.Text;
using System.IO;

byte[] data = Read();

_ = Utf8Parser.TryParse(data, out int rounds, out _);

double pi = 1;
double x = 1;

for (int i = 2; i < rounds + 2; i++) {
    x *= -1;
    pi += (x / (2 * i - 1));
}

pi *= 4;
Console.WriteLine(pi);

static byte[] Read()
{
    try {
        return File.ReadAllBytes("rounds.txt");
    } catch (IOException err) {
        Console.WriteLine($"Couldn't read file:\n {err.Message}");
        Environment.Exit(1);
        return null; // unreachable
    }
}
