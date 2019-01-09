# Raspberry Pi 3B GPIO Test Panel

Controls all GPIO pins available on the Raspberry Pi model 3B

## Requirements

  * Raspberry Pi 3B with Windows 10 IOT 10.0.17134.1
  * Pi Foundation 7" Touchscreen Display (It's hardcoded for 800x480 resolution)
  
## Features and Usage

A pin can be configured as input or output in the left two columns. Its status is shown in the right two columns. If a pin is configured as input, then changing its state will cause the appropriate right-hand toggle switch to change. If it's configured as output, then toggling the appropriate control will drive it low or high.

Additionally, all pins can be set at once, to either input or output, or if configured as output, can drive them all low or high simultaneously.
