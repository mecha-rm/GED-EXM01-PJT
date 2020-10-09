#include "Wrapper.h"

// time logger
CheckpointTimeLogger timeLogger;

PLUGIN_API void ResetLogger()
{
	return timeLogger.ResetLogger();
}

PLUGIN_API void SaveCheckpointTime()
{
	return timeLogger.SaveCheckpointTime();
}

PLUGIN_API float GetTotalTime()
{
	return timeLogger.GetTotalTime();
}

PLUGIN_API float GetTimeSinceLastCheckpoint()
{
	return timeLogger.GetTimeSinceLastCheckpoint();
}

PLUGIN_API float GetCheckpointTime(int index)
{
	return timeLogger.GetCheckpointTime(index);
}

PLUGIN_API int GetNumberOfCheckpoints()
{
	return timeLogger.GetNumberOfCheckpoints();
}

PLUGIN_API void UpdateLogger(float deltaTime)
{
	return timeLogger.UpdateLogger(deltaTime);
}
