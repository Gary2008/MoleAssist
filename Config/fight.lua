import ('System')
import ('System.Windows.Forms')
import ('System.Drawing')


-- these following variable will be assigned when StartFight
local _fighting = false
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

function StartFight()
	_fighting = true
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

	while(_fighting)
	do
		if FightType == "Wild" then
			FightWild()
		elseif FightType == "NPC" then
			FightNPC(FightOptions.NPC)
		elseif FightType == "CustomPoint" then
			FightCustomPoint(FightOptions.customPoint)
		end
	end
end

function StopFight()
	_fighting = false
	MsgBox("stoped")
end


function FightWild()

end

function FightNPC(npc)

end

function FightCustomPoint(point)
	-- point is C# struct System.Drawing.Point
	MsgBox('刷怪坐标是：'..tostring(customPoint.X)..','..tostring(customPoint.Y))
	Click(customPoint.X, customPoint.Y)
end

