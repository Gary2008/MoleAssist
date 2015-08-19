import ('System')
import ('System.Windows.Forms')
import ('System.Drawing')

-- these following variable will be assigned when StartFight
local handle
local FightType
-- local interval -- number
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

function Set()
	handle = FightOptions.handle
	FightType = FightOptions.type
	-- interval = FightOptions.interval
	skillMode = FightOptions.skillMode
	skillOrder = FightOptions.skillOrder
	-- identifyFailed = FightOptions.identifyFailed
	ReHP = FightOptions.ReHP
	-- useAnger = FightOptions.useAnger
	-- alert = FightOptions.alert
	-- qucikTraining = FightOptions.qucikTraining
	-- couldHiddenMode = FightOptions.couldHiddenMode
	local s = tonumber(FightOptions.skillOrder)
end

function Fight()
	if FightCall_couldUseSkill() then
		FightCall_UseSkill(0)
	end
	FightCall_OnlineTime()
	FightCall_GetGoods()
	FightCall_Profile()
	FightCall_SkillLvUp()
	FightCall_hasVerify()
	FightCall_FightEnd()
	if ReHP or FightCall_PetDie() then
		FightCall_FullHP()
	end
	if FightType == "Wild" then
		FightWild()
	elseif FightType == "NPC" then
		FightNPC(FightOptions.NPC)
	elseif FightType == "CustomPoint" then
		FightCustomPoint(FightOptions.customPoint)
	end
end


function FightWild()
	FightCall_FindAndClickMonster()
end

function FightNPC(npc)
	Trace("FightNPC!")
end

function FightCustomPoint(point)
	Click(point.X, point.Y)
end

