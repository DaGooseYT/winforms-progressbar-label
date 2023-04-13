# Windows Forms Progress Bar Label
![alt-text](https://github.com/DaGooseYT/winforms-progressbar-label/blob/main/progressbarlabel.gif)

A simply utility that allows you to put text over a winforms progress bar WITHOUT repainting the progress bar and removing the animation. Text is automatically centered in the progress bar.

## Features
- ProgressText property to set the text over the progress bar.
- TextColor property to set the text's color.
- TextFont property to set the text font.

## Usage

```C#
this.progressBarLabel1 = new Progress.ProgressBarLabel();

// Set custom properties
this.progressBarLabel1.ProgressText = "Your Text Here (83%)";
this.progressBarLabel1.TextColor = System.Drawing.Color.Black;
this.progressBarLabel1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
```
