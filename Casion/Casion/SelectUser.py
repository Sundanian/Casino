from System import Console
import sqlite3 as lite
import sys

con = None
playerId = 0
playerName = ""
playerMoney = 0

try:
    con = lite.connect('Users.db')
    
    cur = con.cursor()    

    
    cur.execute("Select * from Player")
    rows=cur.fetchall()
    for row in rows:
        print "Save ID", row[0]
        print "Save Name", row[1]
        print "Save Money", row[2]

    Console.WriteLine("Select a save file (Write the ID number)")
    playerinput = Console.ReadLine()

  
    with con: 
        cur.execute("Select * from Player where Id = " + playerinput)
    playersave = cur.fetchall()
    for row in playersave:
        playerId = row[0]
        playerName = row[1]
        playerMoney = row[2]

except lite.Error, e:    
    print "Error %s:" % e.args[0]
    sys.exit(1)
    
finally:
    if con:
        con.close()