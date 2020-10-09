#include "CheckpointTimeLogger.h"

// resets the logger
void CheckpointTimeLogger::ResetLogger()
{
	checkpointTimes.clear();
	totalTime = 0.0F;
	elapsedTime = 0.0F;
}

// saves the checkpoint time
void CheckpointTimeLogger::SaveCheckpointTime()
{
	// saves
	checkpointTimes.push_back(elapsedTime);
	elapsedTime = 0.0F;
}

// returns the total time that has passed.
float CheckpointTimeLogger::GetTotalTime() const
{
	return totalTime;
}

// returns time since last checkpoint.
float CheckpointTimeLogger::GetTimeSinceLastCheckpoint() const
{
	return elapsedTime;
}

// gets the checkpoint time
float CheckpointTimeLogger::GetCheckpointTime(int index)
{
	// the index is within range
	if (index >= 0 && index < checkpointTimes.size())
		return checkpointTimes[index];
	else // not within range
		return 0.0F;
}

// returns the number of checkpoints reached.
int CheckpointTimeLogger::GetNumberOfCheckpoints() const
{
	return checkpointTimes.size();
}

// update logger
void CheckpointTimeLogger::UpdateLogger(float deltaTime)
{
	elapsedTime += deltaTime;
	totalTime += deltaTime;
}
