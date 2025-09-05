import activitiesData from "~/assets/data/activities.json";
import type { Activity } from "~/types/game";

export function getActivities(): Activity[] {
  return activitiesData.map((activity) => ({
    ...activity,
    threatening: activity.threatening === "maybe" || activity.threatening === true ? activity.threatening : false,
  }));
}
