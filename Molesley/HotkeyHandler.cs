﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molesley
{
  using System.Windows.Input;

  using GlobalHotKey;

  public class HotkeyHandler
  {
    private HotKeyManager _hotKeyManager;
    private SpotifyHandler _spotifyHandler;

    public HotkeyHandler(HotKeyManager hotKeyManager, SpotifyHandler spotifyHandler)
    {
      _hotKeyManager = hotKeyManager;
      _spotifyHandler = spotifyHandler;
    }

    public void SetupHotKeys()
    {
      try
      {
        _hotKeyManager.Register(Key.P, ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Shift);
        _hotKeyManager.Register(Key.Add, ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Shift);
        _hotKeyManager.Register(Key.Subtract, ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Shift);
        _hotKeyManager.KeyPressed += this.HotKeyPressed;
      }
      catch
      {
      }
    }

    private void HotKeyPressed(object sender, KeyPressedEventArgs args)
    {
      switch (args.HotKey.Key)
      {
        case Key.P:
          _spotifyHandler.SendAction(SpotifyAction.PlayPause);
          break;
        case Key.Add:
          _spotifyHandler.SendAction(SpotifyAction.NextTrack);
          break;
        case Key.Subtract:
          _spotifyHandler.SendAction(SpotifyAction.PreviousTrack);
          break;
      }
    }
  }
}
