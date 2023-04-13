# Windows Forms Progress Bar Label
![alt-text](https://github.com/DaGooseYT/winforms-progressbar-label/blob/main/progressbarlabel.gif)

A simply utility that allows you to put text over a winforms progress bar WITHOUT repainting the progress bar and removing the animation.

## Features
- ProgressText property
- TextColor property
- TextFont property

## Usage

```C#
this.progressBarLabel1 = new EncodeProg.ProgressBarLabel();

// Set custom properties
this.progressBarLabel1.ProgressText = "Your Text Here (unknown progress)";
this.progressBarLabel1.TextColor = System.Drawing.Color.Black;
this.progressBarLabel1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
```
