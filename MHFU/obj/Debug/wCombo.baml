   M S B A M L   `   `   `  ����  MHFU    MHFU.wCombo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Combo��5   	   $	��300��6   $	��650��6$    � Icon$! images/items/White Book.png��60   .��5      � .+�5   
   ]� .+�5      ]� $	��Top=�6   .+�5      �� -   5        $��	TxtRefine��5      $��4q�6@    
  Search#��[  6K   5	      &   System.Windows.Controls.DataGrid  5
      -   5        $��dgTable��5
       
 Header   ColumnHeaderStyle# [ 6>     Alchemy   RowStyle# [ 6j   ��6&   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *ID+4  .System.Windows.Controls.DataGridTemplateColumn  5        ComboRColumn   CellTemplate# [ 6-     5      $ Result��6)     EmphasizedColumn   	CellStyle# [ 6W    69   �� *	Item.Name+6W     5        Combo1Column# [ 6-   6\     5      $ Item A��6)    69   �� *
Item1.Name+  5        Combo2Column# [ 6-   6\     5      $ Item B��6)    69   �� *
Item2.Name+  5      $ 	Success %��6)     
Percentage# [ 6m    6<   �� *	Success+	 �� StringFormat$
	 {0}%��6m     5      $ Quantity��6)    6;   �� *
Quantity+5      5      5      5      