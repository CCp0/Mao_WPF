   M S B A M L   `   `   `  ����>  :Mao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MaoMao  5   	       Mao.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Mao     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $	��24* �6   �� 5      $	��24* �6   �� 5      $	��24* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � 	Resources 5   
      AddButtonImageBrush �� ImageSource j� Stretch��%W   &	        �� 5      $  /images/cards/cardback.png��65   $ UniformToFill=�6^   5      .+�5   
   �� -   5         ��Name$ table��5      $	��300��6    $��Center=�6-   $��5��6J   $��5��6W   $��Center=�6k   $	��772��6�   
��� � �6�   �� 5   
   $��Actions��6   $��Center=�6"   $��0��6?   $��0��6L   $	��Top=�6\   �� 5    
   -   5         ��Name$ btnMao��5       $	��Mao��6!   $��Center=�6/   $��1��6L   $��0��6Y   $	��Top=�6i   $��75��6�   6�   �� 5!   
   -   5        $ 	btnMaoMao��5!      $��Mao Mao��6$   $��Center=�66   $��2��6S   $��0��6`   $	��Top=�6p   $��75��6�   6�   �� 5"   
   -   5        $ 
btnConcede��5"      $��Concede��6%   $��Center=�67   $��3��6T   $��0��6a   $	��Top=�6q   $��75��6�   6�   �� 5#   
   -   5        $ btnDeck��5#      $��Center=�6"   $��5��6?   $��1��6L   $	��Top=�6\   $��52��6t   $��77��6     ButtonStyle#��[ 6�   #��[  6�   6�   �� 5$   
   $	��100��6   $��Center=�6   $��0��6:   $��2��6G   $��4��6W   $��Bottom=�6h   $��72��6�   $��images/icons/dealer.png��6�   �� 5%   
   -   5        $ btnLeaderboard��5%      $��Leaderboard��6)   $��Center=�6?   $��0��6\   $��4��6i   $��Bottom=�6y   $��75��6�   6�   �� 5&   
   $��Streak: ��6   $��Center=�6#   $��1��6@   $��4��6M   $��Center=�6]   �� 5'   
   -   5         ��Name$ 	lblStreak��5'      $�� ��6#   $��Right=�6.   $��1��6J   $��4��6W   $��Center=�6g   $��65��6�   5(      5)      