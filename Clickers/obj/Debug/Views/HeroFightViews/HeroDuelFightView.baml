   M S B A M L   `   `   `  ����C  ?Clickers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Clickers.Views.HeroFightViewsClickers.Views.HeroFightViews  5      M+clr-namespace:Clickers.Views.HeroFightViewsClickers.Views.HeroFightViews  5      5    /Clickers.Views.HeroFightViews.HeroDuelFightView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Clickers.Views.HeroFightViews     5      :sk+clr-namespace:Clickers.Views.HeroFightViews     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��0.2* �6   �� 5      $��* �6   �� 5      $
��0.2* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6/   $��Center=�6<   $��Center=�6Y   .+�5      �� $��Turn ��6   �� 5      -   5         ��Name$ TurnTB��5      ��6(   �� *Turn+5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   �� 5      $��* �6#   �� 5      $��2* �6#   �� 5      $��* �6#   .+�5       �� -   5         ��Name$ AllyHeroAttributesSP��5       .+�5!      �� $��Caractéristiques��6   �� 5"      $ 
Horizontal=�6   .+�5#      �� $��HP : ��6    �� 5$      ��6    �� *Life+ �� UpdateSourceTrigger$ PropertyChanged=�5%      �� 5&      $ 
Horizontal=�6   .+�5'      �� $��Armor : ��6    �� 5(      ��6    �� *Armor+$ PropertyChanged=�5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $��
Attaque : ��6    �� 5,      ��6    �� *AttackValue+$ PropertyChanged=�5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� $��	Niveau : ��6    �� 50      ��6    �� *Level+$ PropertyChanged=�51      52      �� 54      -   5        $ 
AllyHeroSP��54      $��1��6-   �� 56      -   5         ��Name$ VersusImage��56      $��2��6)   $��Center=�69   �� 58      -   5        $ EnnemyHeroSP��58      $��3��6/   �� 5:      -   5        $ EnnemyHeroAttributesSP��5:      $��4��69   .+�5;      �� $��Caractéristiques��6   �� 5<      $ 
Horizontal=�6   .+�5=      �� $��HP : ��6    �� 5>      ��6    �� *Life+$ PropertyChanged=�5?      �� 5@      $ 
Horizontal=�6   .+�5A      �� $��Armor : ��6    �� 5B      ��6    �� *Armor+$ PropertyChanged=�5C      �� 5D      $ 
Horizontal=�6   .+�5E      �� $��
Attaque : ��6    �� 5F      ��6    �� *AttackValue+$ PropertyChanged=�5G      �� 5H      $ 
Horizontal=�6   .+�5I      �� $��	Niveau : ��6    �� 5J      ��6    �� *Level+$ PropertyChanged=�5K      5L      5N      � 5P   
   -   5         �Name$ 
SkillsGrid��5P      $��2��6#    5Q      �� 5R      $��* �6#   �� 5S      $��* �6#   �� 5T      $��* �6#   �� 5U      $��* �6#   �� 5V      $��* �6#   .+�5Y      �� -   5         ��Name$ ItemsButton��5Y      $��3��6*   $��Objets��6:   �� 5Z      -	   5        $ ValidateButton��5Z      $��4��6-   $��Valider��6=   5\      5]      5^      