   M S B A M L   `   `   `  ����   ProjetGhibli1    +ProjetGhibliTicketApp.AdminTicketViewWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Vue des Tickets (Admin)��$	��700��$
��1100�� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $��* ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -     Name$ TicketsDataGrid��$��0��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *	id_ticket+  $ 
Nom Ticket��	 �� *
nom_ticket+  $ Demande��	 �� *	demande+  $ Date Creation��	 �� *date_creation+  $ Utilisateur ID��	 �� *id_utilisateur+  $ Technicien ID��	 �� *id_technicien+  $ 	Categorie��	 �� *	categorie+  $ Service��	 �� *	service+  $ Statut��	 �� *statut+  $ 
Technicien��	 �� *
technicien+  $ Priorite��	 �� *
priorite+  $ Description��	 �� *description+  $ Nom Utilisateur��	 �� *nom_utilisateur+�� $��1��
 �� Orientation$
 
Horizontal=�$��0,10,0,0q�$��Center=�.+��� .+��� $��Statut:��$��0,0,0,5q��� -    ��Name$ StatutComboBox��$	��120��.@��� $��
En attente���� $��En cours���� $��Resolu���� .+��� $��	Priorite:��$��0,0,0,5q��� -   $ PrioriteComboBox��$	��120��.@��� $��Faible���� $��Moyenne���� $��Elevee���� -    ��Name$ UpdateButton��$��Mettre a jour��$	��150��$��35��$��20,0,0,0q�