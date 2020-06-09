// Decompiled with JetBrains decompiler
// Type: CounterStrikeAnnouncer.Program
// Assembly: CounterStrikeAnnouncer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B430407B-F596-411E-A84B-0186B9542B95
// Assembly location: C:\Users\user\Desktop\Decompile\CounterStrikeAnnouncer\CounterStrikeAnnouncer.exe

using System;
using System.Windows.Forms;

namespace CounterStrikeAnnouncer
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
