import { Request, Response, NextFunction } from "express";
import { AnyZodObject, z } from "zod";

const validate =
  (schema: AnyZodObject) =>
  async (req: Request, res: Response, next: NextFunction) => {
    try {
      await schema.parseAsync(req.body);
      next();
    } catch (error) {
      let err = error;
      if (err instanceof z.ZodError) {
        err = err.issues.map((e) => ({ path: e.path[0], message: e.message }));
      }
      return res.status(400).json({
        status: "failed",
        error: err,
      });
    }
  };

export default validate;
