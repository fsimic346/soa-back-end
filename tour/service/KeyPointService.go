package service

import (
	"fmt"
	"tour/model"
	"tour/repo"
)

type KeyPointService struct {
	KeyPointRepo *repo.KeyPointRepository
}

func (service *KeyPointService) FindById(id string) (*model.KeyPoint, error) {
	keyPoint, err := service.KeyPointRepo.FindById(id)
	if err != nil {
		return nil, fmt.Errorf("failed to find key point with ID %s: %w", id, err)
	}
	return &keyPoint, nil
}

func (service *KeyPointService) Create(keyPoint model.KeyPoint) (model.KeyPoint, error) {
	response, err := service.KeyPointRepo.Create(keyPoint)
	if err != nil {
		return response, fmt.Errorf("failed to create key point: %w", err)
	}
	return response, nil
}

func (service *KeyPointService) FindAll() ([]model.KeyPoint, error) {
	keyPoints, err := service.KeyPointRepo.FindAll()
	if err != nil {
		return nil, fmt.Errorf("failed to retrieve key points: %w", err)
	}
	return keyPoints, nil
}
