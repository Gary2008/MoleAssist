import ('System')
import ('System.Windows.Forms')
import ('System.Drawing')


-- these following variable will be assigned when StartFight
local handle
local FightType
local interval -- number
local skillMode -- number
local skillOrder -- string
-- local identifyFailed -- number
-- local ReHP -- boolean
-- local useAnger -- boolean
-- local alert -- boolean
-- local qucikTraining -- boolean
-- local couldHiddenMode -- boolean

function MsgBox(str)  
	MessageBox.Show(str, "")
end

function Fight()
	handle = FightOptions.handle
	FightType = FightOptions.type
	interval = FightOptions.interval
	skillMode = FightOptions.skillMode
	skillOrder = FightOptions.skillOrder
	-- identifyFailed = FightOptions.identifyFailed
	-- ReHP = FightOptions.ReHP
	-- useAnger = FightOptions.useAnger
	-- alert = FightOptions.alert
	-- qucikTraining = FightOptions.qucikTraining
	-- couldHiddenMode = FightOptions.couldHiddenMode
	if FightType == "Wild" then
		FightWild()
	elseif FightType == "NPC" then
		FightNPC(FightOptions.NPC)
	elseif FightType == "CustomPoint" then
			FightCustomPoint(FightOptions.customPoint)
	end
end


function FightWild()
	Trace("FightWild!")
end

function FightNPC(npc)
	Trace("FightNPC!")
end

function FightCustomPoint(point)
	-- point is C# struct System.Drawing.Point
	MsgBox('刷怪坐标是：'..tostring(point.X)..','..tostring(point.Y))
	Click(point.X, point.Y)
end

