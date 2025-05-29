﻿using System;
using System.Text.Json.Serialization;

using Godot;

using RoverControlApp.Core.JSONConverters;

namespace RoverControlApp.Core.Settings;

[JsonConverter(typeof(JoystickConverter))]
public partial class Joystick : SettingBase, ICloneable
{

	public Joystick()
	{
		_roverDriveController = 3;
		_toggleableKinematics = false;
		_minimalInput = 0f;
		_vibrateOnModeChange = true;
	}

	public Joystick(int roverDriveController, bool toggleableKinematics, float minimalInput, bool vibrateOnModeChange)
	{
		_roverDriveController = roverDriveController;
		_toggleableKinematics = toggleableKinematics;
		_minimalInput = minimalInput;
		_vibrateOnModeChange = vibrateOnModeChange;
	}

	public object Clone()
	{
		return new Joystick()
		{
			RoverDriveController = _roverDriveController,
			ToggleableKinematics = _toggleableKinematics,
			MinimalInput = _minimalInput,
			VibrateOnModeChange = _vibrateOnModeChange
		};
	}

	[SettingsManagerVisible(
		cellMode: TreeItem.TreeCellMode.Range,
		formatData:"0;3;1;f;i",
		customTooltip:	"0 - GoodOldGamesLikeController\n" +
						"1 - EricSOnController\n" +
						"2 - ForzaLikeController\n" +
						"3 - DirectDriveController (Default)"
	)]
	public int RoverDriveController
	{
		get => _roverDriveController;
		set => EmitSignal_SettingChanged(ref _roverDriveController, value);
	}

	[SettingsManagerVisible(cellMode: TreeItem.TreeCellMode.Check)]
	public bool ToggleableKinematics
	{
		get => _toggleableKinematics;
		set => EmitSignal_SettingChanged(ref _toggleableKinematics, value);
	}

	[SettingsManagerVisible(cellMode: TreeItem.TreeCellMode.Range, formatData: "0;1;0.01;f;f", customTooltip: "Value lower than this will count as no input. (0 - disable)")]
	public float MinimalInput
	{
		get => _minimalInput;
		set => EmitSignal_SettingChanged(ref _minimalInput, value);
	}

	[SettingsManagerVisible(cellMode: TreeItem.TreeCellMode.Check)]
	public bool VibrateOnModeChange
	{
		get => _vibrateOnModeChange;
		set => EmitSignal_SettingChanged(ref _vibrateOnModeChange, value);
	}

	int _roverDriveController;
	private bool _toggleableKinematics;
	float _minimalInput;
	bool _vibrateOnModeChange;
}



