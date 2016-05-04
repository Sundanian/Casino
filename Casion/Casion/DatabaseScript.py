import sqlite3 as lite
import sys


con = None
existingPlayers = True

try:
    con = lite.connect('Users.db')
    
    cur = con.cursor()    

    cur.execute("CREATE TABLE if not exists Player(Id INTEGER PRIMARY KEY, Name TEXT, Money int)") 
    
    with con:
        cur.execute("DELETE FROM Player WHERE Money = 0")

    #Tjekker om der er noget i databasen
    cur.execute("Select * from Player")
    rows = cur.fetchall()
    print ""
    i = 0 #Number of rows
    for row in rows:
        print "Save ID", row[0]
        print "Save Name", row[1]
        print "Save Money", row[2]
        print ""
        i += 1   
    if i == 0:
        existingPlayers = False
             
except lite.Error, e:
    
    print "Error %s:" % e.args[0]
    sys.exit(1)
    
finally:
    if con:
        con.close()







#import sqlite3 as lite
#import sys

#con = lite.connect('test.db')
#cur = con.cursor()


#cur.execute("CREATE TABLE if not exists Player(Id INTEGER PRIMARY KEY, Name TEXT, Money int)")
#cur.execute("INSERT INTO Player VALUES(NULL, 'Morten', 500)")
#con.commit()

#with con:
#    cur.execute("Select * from Player")
#    rows=cur.fetchall()
#    for row in rows:
#        print(row)