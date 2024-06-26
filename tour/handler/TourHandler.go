package handler

import (
	"encoding/json"
	"net/http"
	"tour/model"
	"tour/service"

	"github.com/gorilla/mux"
)

type TourHandler struct {
	TourService *service.TourService
}

func (handler *TourHandler) FindAll(writer http.ResponseWriter, req *http.Request) {
	tours, err := handler.TourService.FindAll()
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
		return
	}

	writer.Header().Set("Content-Type", "application/json")
	json.NewEncoder(writer).Encode(tours)
}

func (handler *TourHandler) FindById(writer http.ResponseWriter, req *http.Request) {
	id := mux.Vars(req)["id"]
	tour, err := handler.TourService.FindById(id)
	writer.Header().Set("Content-Type", "application/json")
	if err != nil {
		writer.WriteHeader(http.StatusNotFound)
		return
	}
	writer.WriteHeader(http.StatusOK)
	json.NewEncoder(writer).Encode(tour)
}

func (handler *TourHandler) FindByAuthor(writer http.ResponseWriter, req *http.Request) {
	id := mux.Vars(req)["id"]
	tours, err := handler.TourService.FindByAuthor(id)
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
		return
	}

	writer.Header().Set("Content-Type", "application/json")
	json.NewEncoder(writer).Encode(tours)
}

func (handler *TourHandler) Create(writer http.ResponseWriter, req *http.Request) {
	var tour model.Tour
	err := json.NewDecoder(req.Body).Decode(&tour)
	if err != nil {
		http.Error(writer, err.Error(), http.StatusBadRequest)
		return
	}

	createdTour, err := handler.TourService.Create(tour)
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
		return
	}

	jsonResponse, err := json.Marshal(createdTour)
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
		return
	}

	writer.Header().Set("Content-Type", "application/json")
	writer.WriteHeader(http.StatusCreated)
	writer.Write(jsonResponse)
}
