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
    rows = cur.fetchall()
    print ""
    i = 0 #Number of rows
    for row in rows:
        print "Save ID", row[0]
        print "Save Name", row[1]
        print "Save Money", row[2]
        print ""
        i += 1        

    while True:
        Console.WriteLine("Select a save file (Write the ID number)")
        playerinput = Console.ReadLine()
        try:
            if int(playerinput) < i+1 and int(playerinput) > 0:
                break
            else:
                print "Please enter something valid"
        except ValueError:
            print "Please enter something valid"

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