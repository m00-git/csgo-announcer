// Decompiled with JetBrains decompiler
// Type: CounterStrikeAnnouncer.Announcer
// Assembly: CounterStrikeAnnouncer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B430407B-F596-411E-A84B-0186B9542B95
// Assembly location: C:\Users\user\Desktop\Decompile\CounterStrikeAnnouncer\CounterStrikeAnnouncer.exe

using CSGSI;
using CSGSI.Nodes;
using NAudio.Wave;
using System;

namespace CounterStrikeAnnouncer
{
  internal class Announcer
  {
    private static Form1 theForm;
    private static IWavePlayer waveOutDevice;
    private static AudioFileReader audioFileReader;
    private static int rnd;
    private static int rndprev;

    private static void playSound(string path)
    {
      try
      {
        Announcer.waveOutDevice.Stop();
      }
      catch
      {
      }
      Announcer.waveOutDevice = (IWavePlayer) new WaveOut();
      Announcer.audioFileReader = new AudioFileReader(path);
      Announcer.audioFileReader.Volume = Announcer.theForm.volu;
      Announcer.waveOutDevice.Init((IWaveProvider) Announcer.audioFileReader);
      Announcer.waveOutDevice.Play();
    }

    public Announcer(Form1 Form)
    {
      GameStateListener gameStateListener = new GameStateListener(3000);
      gameStateListener.NewGameState += new NewGameStateHandler(Announcer.OnNewGameState);
      if (!gameStateListener.Start())
        Environment.Exit(0);
      Console.WriteLine("Listening...");
      Announcer.theForm = Form;
    }

    private static void OnNewGameState(GameState gs)
    {
      try
      {
        Announcer.rnd = gs.Map.Round;
        Announcer.rndprev = gs.Previously.Map.Round;
      }
      catch
      {
        Console.WriteLine("exception occured");
      }
      if (Announcer.theForm.game == 0)
      {
        if (gs.Player.State.RoundKills != gs.Previously.Player.State.RoundKills && gs.Player.State.RoundKills != 0 && (gs.Player.State.RoundKills != -1 && gs.Previously.Player.State.RoundKills != -1) && gs.Player.SteamID == gs.Provider.SteamID)
        {
          if (gs.Player.MatchStats.Kills != 5 && gs.Player.MatchStats.Kills != 10 && (gs.Player.MatchStats.Kills != 15 && gs.Player.MatchStats.Kills != 20) && (gs.Player.MatchStats.Kills != 25 && gs.Player.MatchStats.Kills != 30))
          {
            if (gs.Player.State.RoundKillHS == gs.Previously.Player.State.RoundKillHS || gs.Player.State.RoundKillHS == 0 || gs.Previously.Player.State.RoundKillHS == -1)
            {
              if (gs.Player.State.RoundKills == 2)
                Announcer.playSound("audio\\doublekill.wav");
              if (gs.Player.State.RoundKills == 3)
                Announcer.playSound("audio\\megakill.wav");
              if (gs.Player.State.RoundKills == 4)
                Announcer.playSound("audio\\monsterkill.wav");
              if (gs.Player.State.RoundKills == 5)
                Announcer.playSound("audio\\holy.wav");
            }
            if (gs.Player.State.RoundKillHS != gs.Previously.Player.State.RoundKillHS && gs.Player.State.RoundKillHS != 0 && (gs.Player.State.RoundKillHS != -1 && gs.Previously.Player.State.RoundKillHS != -1))
            {
              if (gs.Player.State.RoundKills == 1)
                Announcer.playSound("audio\\hs\\headshot.wav");
              if (gs.Player.State.RoundKills == 2)
                Announcer.playSound("audio\\hs\\hsdoublekill.wav");
              if (gs.Player.State.RoundKills == 3)
                Announcer.playSound("audio\\hs\\hsmegakill.wav");
              if (gs.Player.State.RoundKills == 4)
                Announcer.playSound("audio\\hs\\hsmonsterkill.wav");
              if (gs.Player.State.RoundKills == 5)
                Announcer.playSound("audio\\hs\\hsholy.wav");
            }
          }
          else
          {
            if (gs.Player.MatchStats.Kills == 5)
              Announcer.playSound("audio\\spree\\spree.wav");
            if (gs.Player.MatchStats.Kills == 10)
              Announcer.playSound("audio\\spree\\rampage.wav");
            if (gs.Player.MatchStats.Kills == 15)
              Announcer.playSound("audio\\spree\\dominating.wav");
            if (gs.Player.MatchStats.Kills == 20)
              Announcer.playSound("audio\\spree\\unstoppable.wav");
            if (gs.Player.MatchStats.Kills == 25)
              Announcer.playSound("audio\\spree\\godlike.wav");
            if (gs.Player.MatchStats.Kills == 30)
              Announcer.playSound("audio\\spree\\wicked.wav");
          }
        }
        if (Announcer.rnd != Announcer.rndprev && Announcer.rndprev == Announcer.rnd - 1)
        {
          if (Announcer.rnd == 14)
            Announcer.playSound("audio\\lockandload.wav");
          if (gs.Map.Phase != gs.Previously.Map.Phase && gs.Map.Phase == MapPhase.GameOver && gs.Previously.Map.Phase != MapPhase.Undefined)
          {
            if (gs.Map.TeamCT.Score > gs.Map.TeamT.Score)
            {
              if (gs.Player.Team == PlayerTeam.CT)
              {
                Announcer.playSound("audio\\win.wav");
                if (gs.Map.TeamT.Score == 0)
                  Announcer.playSound("audio\\flawless.wav");
              }
              if (gs.Player.Team == PlayerTeam.T)
              {
                Announcer.playSound("audio\\lose.wav");
                if (gs.Map.TeamT.Score == 0)
                  Announcer.playSound("audio\\humiliating.wav");
              }
            }
            if (gs.Map.TeamT.Score > gs.Map.TeamCT.Score)
            {
              if (gs.Player.Team == PlayerTeam.T)
              {
                Announcer.playSound("audio\\win.wav");
                if (gs.Map.TeamCT.Score == 0)
                  Announcer.playSound("audio\\flawless.wav");
              }
              if (gs.Player.Team == PlayerTeam.CT)
              {
                Announcer.playSound("audio\\lose.wav");
                if (gs.Map.TeamCT.Score == 0)
                  Announcer.playSound("audio\\humiliating.wav");
              }
            }
          }
        }
      }
      if (Announcer.theForm.game != 1)
        return;
      if (gs.Player.State.RoundKills != gs.Previously.Player.State.RoundKills && gs.Player.State.RoundKills != 0 && (gs.Player.State.RoundKills != -1 && gs.Previously.Player.State.RoundKills != -1) && gs.Player.SteamID == gs.Provider.SteamID)
      {
        if (gs.Player.MatchStats.Kills != 5 && gs.Player.MatchStats.Kills != 10 && (gs.Player.MatchStats.Kills != 15 && gs.Player.MatchStats.Kills != 20) && (gs.Player.MatchStats.Kills != 25 && gs.Player.MatchStats.Kills != 30 && (gs.Player.MatchStats.Kills != 35 && gs.Player.MatchStats.Kills != 40)))
        {
          if (gs.Player.State.RoundKills == 2)
            Announcer.playSound("audio\\halo\\doublekill.wav");
          if (gs.Player.State.RoundKills == 3)
            Announcer.playSound("audio\\halo\\triplekill.wav");
          if (gs.Player.State.RoundKills == 4)
            Announcer.playSound("audio\\halo\\overkill.wav");
          if (gs.Player.State.RoundKills == 5)
            Announcer.playSound("audio\\halo\\killtacular.wav");
        }
        else
        {
          if (gs.Player.MatchStats.Kills == 5)
            Announcer.playSound("audio\\halo\\spree\\spree.wav");
          if (gs.Player.MatchStats.Kills == 10)
            Announcer.playSound("audio\\halo\\spree\\frenzy.wav");
          if (gs.Player.MatchStats.Kills == 15)
            Announcer.playSound("audio\\halo\\spree\\riot.wav");
          if (gs.Player.MatchStats.Kills == 20)
            Announcer.playSound("audio\\halo\\spree\\rampage.wav");
          if (gs.Player.MatchStats.Kills == 25)
            Announcer.playSound("audio\\halo\\spree\\untouch.wav");
          if (gs.Player.MatchStats.Kills == 30)
            Announcer.playSound("audio\\halo\\spree\\invincible.wav");
          if (gs.Player.MatchStats.Kills == 35)
            Announcer.playSound("audio\\halo\\spree\\inconceivable.wav");
          if (gs.Player.MatchStats.Kills == 40)
            Announcer.playSound("audio\\halo\\spree\\friggin.wav");
        }
      }
      if (Announcer.rnd == Announcer.rndprev || Announcer.rndprev != Announcer.rnd - 1)
        return;
      if (Announcer.rnd == 14)
        Announcer.playSound("audio\\halo\\ordnance.wav");
      if (gs.Map.Phase == gs.Previously.Map.Phase || gs.Map.Phase != MapPhase.GameOver || gs.Previously.Map.Phase == MapPhase.Undefined)
        return;
      if (gs.Map.TeamCT.Score > gs.Map.TeamT.Score)
      {
        if (gs.Player.Team == PlayerTeam.CT)
          Announcer.playSound("audio\\halo\\win.wav");
        if (gs.Player.Team == PlayerTeam.T)
          Announcer.playSound("audio\\halo\\lose.wav");
      }
      if (gs.Map.TeamT.Score <= gs.Map.TeamCT.Score)
        return;
      if (gs.Player.Team == PlayerTeam.T)
        Announcer.playSound("audio\\halo\\win.wav");
      if (gs.Player.Team != PlayerTeam.CT)
        return;
      Announcer.playSound("audio\\halo\\lose.wav");
    }
  }
}
