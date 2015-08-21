import ('System')
import ('System.Windows.Forms')
import ('System.Drawing')

function MsgBox(str)  
	MessageBox.Show(str, "")
end

use = 0 -- used skill index
skillTable = {}
findInterval = 5
lastfind = os.clock() - findInterval

-- function initialize these values
function Set()
	Trace("Set()")
	-- these following variable will be assigned when press StartFight button
	-- FightOptions.handle
	-- FightOptions.type -- string
	-- FightOptions.interval
	-- FightOptions.skillMode -- number
	-- FightOptions.skillOrder -- string
	-- FightOptions.identifyFailed -- number
	-- FightOptions.ReHP -- boolean
	-- FightOptions.useAnger -- boolean
	-- FightOptions.alert -- boolean
	-- FightOptions.qucikTraining -- boolean
	-- FightOptions.couldHiddenMode -- boolean
	local skillOrder = FightOptions.skillOrder
	if (skillOrder == "") then
		skillOrder = "1"
	end
	Trace("skillOrderLen"..tostring(string.len(skillOrder)))
	-- lua index starts from 1
	for i=1, string.len(skillOrder) do
		-- get the char from position i to i
		Trace("ST"..tostring(i).. tonumber( string.sub(skillOrder, i, i)) )
		_G.skillTable[i] = tonumber( string.sub(skillOrder, i, i) )
	end
end

function Fight()
	Trace("Fight()")
	Trace(FightOptions.type)
	use = use + 1
	if (FightOptions.skillMode == 0 or use > #skillTable) then
	 	use = 1
	end
	-- Trace("2")
	if FightCall_couldUseSkill() then
		Trace("UseI"..tostring(use))
		Trace("Use"..tostring(skillTable[use]))
		FightCall_UseSkill(skillTable[use])
	end
	-- Trace("3")
	FightCall_OnlineTime()
	-- Trace("3")
	FightCall_GetGoods()
	-- Trace("4")
	FightCall_Profile()
	-- Trace("5")
	FightCall_SkillLvUp()
	-- Trace("6")
	if FightCall_hasVerify() == 2 then
		MessageBox.Show("出现了无法识别的验证！！！", "!!!")
	end
	-- Trace("7")
	if FightCall_FightEnd() == true then
		use = 0
		Trace("Clear")
	end
	--Trace("8")
	if FightOptions.type == "Wild" then
		-- Trace("9")
		FightWild()
		-- Trace("10")
	elseif FightOptions.type == "NPC" then
		-- Trace("11")
		FightNPC(FightOptions.NPC)
		-- Trace("12")
	elseif FightOptions.type == "CustomPoint" then
		-- Trace("13")
		FightCustomPoint(FightOptions.customPoint)
		-- Trace("14")
	end
	if FightOptions.ReHP and FightCall_PetDie() then
		-- Trace("15")
		FightCall_FullHP()
		-- Trace("16")
	end
end


function FightWild()
	Trace("Find!")
	if (os.clock() - lastfind < findInterval) then
		return
	end
	lastfind = os.clock()
	FightCall_FindAndClickMonster()
end

function FightNPC(npc)
	Trace("FightNPC!")
end

function FightCustomPoint(point)
	Trace("Find!")
	if (os.clock() - lastfind < findInterval) then
		return
	end
	lastfind = os.clock()
	Click(point.X, point.Y)
end

