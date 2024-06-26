import { object, string, number, z, boolean } from "zod";
import { EncounterInstanceSchema } from "./encounterInstance.schema";

export const EncounterSchema = object({
  title: string({
    required_error: "Title is required",
  }).min(3, "Title is too short."),
  description: string({
    required_error: "Description is required",
  }),
  picture: string({
    required_error: "picture is required",
  }),
  longitude: number({
    required_error: "Longitude is required",
  })
    .lt(180, "Invalid longitude value")
    .gt(-180, "Invalid longitude value"),
  latitude: number({
    required_error: "Latitude is required",
  })
    .lt(90, "Invalid latitude value")
    .gt(-90, "Invalid latitude value"),
  radius: number({
    required_error: "radius is required",
  }).gt(0, "Invalid radius value"),
  xpReward: number({
    required_error: "Xp reward is required",
  }).gt(0, "Invalid xp reward value"),
  status: number({
    required_error: "Encounter status is required",
  })
    .gte(0, "Invalid encounter status value")
    .lte(2, "Invalid encounter status value"),
  type: number({
    required_error: "Encounter type is required",
  })
    .gte(0, "Invalid encounter type value")
    .lte(4, "Invalid encounter type value"),
  instances: EncounterInstanceSchema.array().optional().nullable(),
});

const HasID = z.object({ id: z.number() });

export const ResponseEncounterSchema = EncounterSchema.omit({
  status: true,
  instances: true,
});
export const MiscEncountersSchema = EncounterSchema.extend({
  challengeDone: boolean(),
});

export const SocialEncounterSchema = EncounterSchema.extend({
  peopleNumber: number({ required_error: "Encounter type is required" }).gte(2),
});

export const HiddenEncounterSchema = EncounterSchema.extend({
  pictureLongitude: number({ required_error: "Encounter type is required" }),
  pictureLatitude: number({ required_error: "Encounter type is required" }),
});

export type EncounterDto = z.infer<typeof EncounterSchemaID>;
export type ResponseEncounterDto = z.infer<typeof ResponseEncounterSchema>;

export const EncounterSchemaID = EncounterSchema.merge(HasID);
const SocialEncounterSchemaID = SocialEncounterSchema.merge(HasID);
const HiddenEncounterSchemaID = HiddenEncounterSchema.merge(HasID);
const MiscEncounterSchemaID = MiscEncountersSchema.merge(HasID);

export type CreateEncounterDto = z.infer<typeof EncounterSchemaID>;
export type CreateMiscEncounterDto = z.infer<typeof MiscEncounterSchemaID>;
export type CreateSocialEncounterDto = z.infer<typeof SocialEncounterSchemaID>;
export type CreateHiddenEncounterDto = z.infer<typeof HiddenEncounterSchemaID>;
